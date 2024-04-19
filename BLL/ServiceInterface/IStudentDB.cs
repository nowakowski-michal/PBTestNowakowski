using BLL.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceInterface
{
    public interface IStudentDB
    {
        StudentResponseDTO AddStudent(StudentRequestDTO student); //po wstawieniu zwroci nowego studenta PROCEDURA
        List<HistoriaResponseDTO> GetHistoryPagined(int strona, int ilosc); 
    }
}
