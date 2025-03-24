using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using EsercizioS7L1.Models;
using EsercizioS7L1.Services;

namespace EsercizioS7L1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }
      
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
            var results = await _studentService.CreateStudentAsync(student);

            if (!results)
            {
                return BadRequest(new { message = "Errore durante la creazione dello studente" });
            }
            return Ok( new
            {
                message = "Studente creato con successo"
            });
        }

        [HttpGet]

        public async Task<IActionResult> GetStudents()
        {
            var studentsList = await _studentService.GetStudentsAsync();
            if (studentsList == null)
            {
                return BadRequest(new { message = "Errore durante la creazione dello studente" });
            }
           
            if(!studentsList.Any()) {

                return NoContent();
            }
            var count = studentsList.Count();

            var text = count > 1 ? $"{count} studenti trovati" : $"{count} studente trovato";

            return Ok(new { 
                message = text,
                students = studentsList 
            });
        }
    }
}
