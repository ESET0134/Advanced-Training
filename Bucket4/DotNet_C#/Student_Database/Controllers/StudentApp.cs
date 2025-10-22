using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Database.Data.Repository;
using Student_Database.Models;

namespace Student_Database.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentApp : ControllerBase
    {

        private readonly ILogger<StudentApp> _logger;
        private readonly IstudentRepository _IstudentRepository;

        public StudentApp(ILogger<StudentApp> logger, IstudentRepository studentRepository)
        {
            _logger = logger;
            _IstudentRepository = studentRepository;
        }

        [HttpGet]
        [Route("All")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Student>>> getStudents()
        {
            var student = await _IstudentRepository.GetAll();
            return Ok(student);
        }

        [HttpGet("{id:Int}", Name = "getstudentsbyid")]
        public async Task<ActionResult<IEnumerable<Student>>> getstudentsbyid(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var students = await _IstudentRepository.GetStudentsByID(id);
            if (students == null)
            {
                return NotFound($"ID: {id} not found");
            }
            return Ok(students);
        }

        [HttpGet("GetDetailsByName")]
        public async Task<ActionResult<IEnumerable<Student>>> getstudentsbyName(string Name)
        {
            if (Name == null)
            {
                return BadRequest();
            }
            var students = await _IstudentRepository.GetStudentsByName(Name);
            if (students == null)
            {
                return NotFound($"Name: {Name} not found");
            }
            return Ok(students);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Student>> CreateStudent([FromBody] Student Model)
        {
            if (Model == null)
            {
                return BadRequest();
            }
            Student studentnew = new Student
            {
                Name = Model.Name,
                Email = Model.Email,
                Age = Model.Age,
                City = Model.City
            };
            var students = await _IstudentRepository.CreateStudent(studentnew);
            if (students == 0)
                return StatusCode(500, "Create failed");
            return Ok(students);
        }

        [HttpDelete("Delete")]
        public async Task<bool> deleteStudent(int id)
        {
            return await _IstudentRepository.DeleteStudent(id);
        }

        [HttpPatch]
        [Route("{id:int}/UpdateStudent")]
        public async Task<IActionResult> UpdateStudentPartial(int id, [FromBody] JsonPatchDocument<Student> patchDocument)
        {
            if (patchDocument == null || id <= 0)
                return BadRequest();

            var existing = await _IstudentRepository.GetStudentsByID(id);
            if (existing == null)
                return NotFound($"ID: {id} not found");

            var studentToPatch = new Student
            {
                Id = existing.Id,
                Name = existing.Name,
                Email = existing.Email,
                Age = existing.Age,
                City = existing.City
            };

            patchDocument.ApplyTo(studentToPatch, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!TryValidateModel(studentToPatch))
                return BadRequest(ModelState);

            var result = await _IstudentRepository.UpdateStudent(studentToPatch);
            if (result == 0)
                return StatusCode(500, "Update failed");

            return NoContent();
        }
    }
}
