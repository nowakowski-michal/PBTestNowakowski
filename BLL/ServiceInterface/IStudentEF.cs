using BLL.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceInterface
{
    public interface IStudentEF
    {
        StudentResponseDTO AddStudent(StudentRequestDTO student); //po wstawieniu zwroci nowego studenta
        bool StudentUpdateGroup(int id, int groupId);
        bool DeleteStudent(int id);
        StudentResponseDTO GetStudentById(int id);
        List<StudentResponseDTO> GetAllStudents();
        List<StudentResponseDTO> GetAllStudentsPagined(int strona, int ilosc);
        List<HistoriaResponseDTO> GetHistoryPagined(int strona, int ilosc);

    }
}
