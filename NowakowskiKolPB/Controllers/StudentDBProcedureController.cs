using BLL.DtoModels;
using BLL.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NowakowskiKolPB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDBProcedureController : ControllerBase
    {
        private readonly IStudentDB _studentService;  //interfejs dla procedur

        public StudentDBProcedureController(IStudentDB studentService)
        {
            _studentService = studentService;
        }
        [HttpPost]
        public IActionResult AddStudent(StudentRequestDTO student)
        {
            try
            {
                var response = _studentService.AddStudent(student);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("history/paginated{strona}/{ilosc}")]
        public IActionResult GetHistoryPaginated(int strona, int ilosc)
        {
            try
            {
                var response = _studentService.GetHistoryPagined(strona, ilosc);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
