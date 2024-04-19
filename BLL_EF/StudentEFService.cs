using BLL.DtoModels;
using BLL.ServiceInterface;
using DAL;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class StudentEFService : IStudentEF
    {
        private readonly WebContext _dbContext;
        public StudentEFService(WebContext dbContext)
        {
            _dbContext = dbContext;
        }
        public StudentResponseDTO AddStudent(StudentRequestDTO student)
        {
            Student newStudent = new Student
            {
                Imie = student.Imie,
                Nazwisko = student.Nazwisko,
                IdGrupy = student.IdGrupy
            };

            _dbContext.Studenci.Add(newStudent);
            _dbContext.SaveChanges();

            var result = _dbContext.Studenci.Include(x => x.Grupa).OrderBy(i => i.Id).LastOrDefault();
            if (result == null)
            {
                throw new Exception("Wyjatek");
            }
            return new StudentResponseDTO
            {
                Id = result.Id,
                Imie = result.Imie,
                Nazwisko = result.Nazwisko,
                NazwaGrupy = result.Grupa.Nazwa != null ? result.Grupa.Nazwa : "brak"
            };
        }

        public bool DeleteStudent(int id)
        {
            Student user = _dbContext.Studenci.Where(x => x.Id == id).OrderBy(i => i.Id).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                //wg mnie to dto nie ma tu sensu ale bylo w poleceniu aby stworzyć to jest :)
                HistoriaRequestDTO historia = new HistoriaRequestDTO
                {
                    Imie = user.Imie,
                    Nazwisko = user.Nazwisko,
                    IdGrupy = user.IdGrupy,
                    DateTime = DateTime.Now,
                    TypAkcji = 1 //dla ulątwienia w dto nie mam enum tylko 0 to edycja a 1 usuwanie
                };
                _dbContext.Historia.Add(new Historia
                {
                    Imie = historia.Imie,
                    Nazwisko = historia.Nazwisko,
                    DateTime = historia.DateTime,
                    IdGrupy = historia.IdGrupy,
                    TypAkcji = (TypAkcji)Enum.Parse(typeof(TypAkcji), historia.TypAkcji.ToString())
                });
                _dbContext.Studenci.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
        }

        public List<StudentResponseDTO> GetAllStudents()
        {
            var users = _dbContext.Studenci.Include(u => u.Grupa).AsQueryable();

            return users.Select(p => new StudentResponseDTO
            {
                Id = p.Id,
                Imie = p.Imie,
                Nazwisko = p.Nazwisko,
                NazwaGrupy = p.Grupa.Nazwa != null ? p.Grupa.Nazwa : "brak"

            }).ToList();

        }

        public List<StudentResponseDTO> GetAllStudentsPagined(int strona, int ilosc)
        {
            return _dbContext.Studenci.Include(g=>g.Grupa).Skip(strona * ilosc)
                   .Take(ilosc)
                   .Select(o => new StudentResponseDTO
                   {
                       Id = o.Id,
                       Imie = o.Imie,
                       Nazwisko = o.Nazwisko,
                       NazwaGrupy = o.Grupa.Nazwa != null ? o.Grupa.Nazwa : "brak"

                   }).ToList();
        }

        public List<HistoriaResponseDTO> GetHistoryPagined(int strona, int ilosc)
        {
            //strony numerowane od 0 bo nic nie było w poleceniu jak ma być od 1 to --strona;
            return _dbContext.Historia.Skip(strona * ilosc).Take(ilosc).Select(o => new HistoriaResponseDTO
            {
                Id = o.Id,
                Imie = o.Imie,
                Nazwisko = o.Nazwisko,
                NazwaGrupy = _dbContext.Grupy.Where(i => i.Id == o.IdGrupy).FirstOrDefault().Nazwa,
                DateTime = o.DateTime,
                TypAkcji = o.TypAkcji.ToString()

            }).ToList();
        }

        public StudentResponseDTO GetStudentById(int id)
        {
            Student user = _dbContext.Studenci.Include(u => u.Grupa).Where(x => x.Id == id).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("Wyjatek");
            }
            else
            {
                return new StudentResponseDTO
                {
                    Id = user.Id,
                    Imie = user.Imie,
                    Nazwisko = user.Nazwisko,
                    NazwaGrupy = user.Grupa.Nazwa != null ? user.Grupa.Nazwa : "brak"
                };
            }
        }

        public bool StudentUpdateGroup(int id, int groupId)
        {
            var result = _dbContext.Studenci.Where(i => i.Id == id).FirstOrDefault();

            var checkGroup = _dbContext.Grupy.Where(i=>i.Id == groupId).FirstOrDefault();
            if (result == null || checkGroup == null)
            {
                return false;
            }
            else
            {
                //wg mnie to dto nie ma tu sensu ale bylo w poleceniu aby stworzyć to jest :)
                HistoriaRequestDTO historia = new HistoriaRequestDTO
                {
                    Imie = result.Imie,
                    Nazwisko = result.Nazwisko,
                    IdGrupy = result.IdGrupy,
                    DateTime = DateTime.Now,
                    TypAkcji = 0 //dla ulątwienia w dto nie mam enum tylko 0 to edycja a 1 usuwanie
                };

                result.IdGrupy = groupId;
                //narazie bez triggera dodawanie historii przy modyfikacji grupy
                _dbContext.Historia.Add(new Historia
                {
                    Imie = historia.Imie,
                    Nazwisko = historia.Nazwisko,
                    DateTime = historia.DateTime,
                    IdGrupy = historia.IdGrupy,
                    TypAkcji = (TypAkcji)Enum.Parse(typeof(TypAkcji), historia.TypAkcji.ToString())
                });

                _dbContext.SaveChanges();
           
                return true;
            }
        }
    }
}
