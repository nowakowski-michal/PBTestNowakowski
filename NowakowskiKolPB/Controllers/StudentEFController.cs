using BLL.DtoModels;
using BLL.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NowakowskiKolPB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentEFController : ControllerBase
    {
        private readonly IStudentEF _studentService;

        public StudentEFController(IStudentEF studentService)
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

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                var response = _studentService.GetStudentById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("history/paginated{strona}/{ilosc}")]
        public IActionResult GetHistoryPaginated(int strona,int ilosc)
        {
            try
            {
                var response = _studentService.GetHistoryPagined(strona,ilosc);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("students/paginated{strona}/{ilosc}")]
        public IActionResult GetAllStudentsPaginated(int strona, int ilosc)
        {
            try
            {
                var response = _studentService.GetAllStudentsPagined(strona,ilosc);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("AllStudents")]
        public IActionResult GetAllStudent()
        {

            try
            {
                var response = _studentService.GetAllStudents();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }


        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var response = _studentService.DeleteStudent(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}/updategroup/{groupId}")]
        public IActionResult StudentUpdateGroup(int id, int groupId)
        {
            try
            {
                var response = _studentService.StudentUpdateGroup(id, groupId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
