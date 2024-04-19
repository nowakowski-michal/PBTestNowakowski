using BLL.DtoModels;
using BLL.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DB
{
    public class StudentDBService : IStudentDB
    {
        public string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NowakowskiMPB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public StudentResponseDTO AddStudent(StudentRequestDTO student)
        {
            throw new NotImplementedException();
        }

        public List<HistoriaResponseDTO> GetHistoryPagined(int strona, int ilosc)
        {
            throw new NotImplementedException();
        }
    }
}
