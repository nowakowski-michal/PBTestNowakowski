using BLL.DtoModels;
using BLL.ServiceInterface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Procedure
{
    public class StudentDBService : IStudentDB
    {
        public string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NowakowskiMPB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public StudentResponseDTO AddStudent(StudentRequestDTO student)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();



                var sql = @"exec dbo.AddStudent @Imie,@Nazwisko,@IdGrupy";


                using (var command = new SqlCommand(sql, connection))
                {

                    command.Parameters.AddWithValue("@Imie", student.Imie);
                    command.Parameters.AddWithValue("@Nazwisko", student.Nazwisko);
                    command.Parameters.AddWithValue("@IdGrupy", student.IdGrupy);


                    using (var reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {

                            reader.Read();

                            return new StudentResponseDTO
                            {
                                Id = reader.GetInt32(0),
                                Imie = reader.GetString(1),
                                Nazwisko = reader.GetString(2),
                                NazwaGrupy = reader.GetString(3)
                            };
                        }
                        else
                        {
                            throw new Exception("Brak wyników.");
                        }
                    }
                }
            }
        }

        public List<HistoriaResponseDTO> GetHistoryPagined(int strona, int ilosc)
        {
            List<HistoriaResponseDTO> history = new List<HistoriaResponseDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "dbo.GetHistoryPaginated";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Offset",strona);
                    command.Parameters.AddWithValue("@PageSize", ilosc);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int historyId = reader.GetInt32(reader.GetOrdinal("Id"));

                        // Sprawdź, czy użytkownik już istnieje na liście
                        HistoriaResponseDTO historia = history.FirstOrDefault(u => u.Id == historyId);
                        int typAkcjiInt = reader.GetInt32(5);
                        string typAkcjiString;

                        if (typAkcjiInt == 0)
                        {
                            typAkcjiString = "Edycja";
                        }
                        else if (typAkcjiInt == 1)
                        {
                            typAkcjiString = "Usuwanie";
                        }
                        else
                        {
                            typAkcjiString = "Nieznany";
                        }
                        if (historia == null)
                        {
                            historia = new HistoriaResponseDTO
                            {
                                Id = reader.GetInt32(0),
                                Imie = reader.GetString(1),
                                Nazwisko = reader.GetString(2),
                                NazwaGrupy = reader.GetString(3),
                                DateTime = reader.GetDateTime(4),
                                TypAkcji = typAkcjiString,
                            };
                            history.Add(historia);
                        }
                    }

                    reader.Close();
                }
            }
            return history;
        }
    }
}
