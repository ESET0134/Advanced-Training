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
            var student = _IstudentRepository.GetAll();
            return Ok(student);
        }

        [HttpGet("{id:Int}", Name = "getstudentsbyid")]
        public ActionResult<IEnumerable<Student>> getstudentsbyid(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var students = _IstudentRepository.GetStudentsByID(id);
            if (students == null)
            {
                return NotFound($"ID: {id} not found");
            }
            return Ok(students);
        }

        [HttpGet("GetDetailsByName")]
        public ActionResult<IEnumerable<Student>> getstudentsbyName(string Name)
        {
            if (Name == null)
            {
                return BadRequest();
            }
            var students = _IstudentRepository.GetStudentsByName(Name);
            if (students == null)
            {
                return NotFound($"Name: {Name} not found");
            }
            return Ok(students);
        }

        [HttpPost("Create")]
        public ActionResult<Student> CreateStudent([FromBody] Student Model)
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
            var students = _IstudentRepository.CreateStudent(studentnew);
            return Ok(students);
        }

        [HttpDelete("Delete")]
        public bool deleteStudent(int id)
        {
            return _IstudentRepository.DeleteStudent(id);
        }

        [HttpPatch]
        [Route("{id:int}/UpdateStudent")]
        public ActionResult updateStudentPartial(int id, [FromBody] JsonPatchDocument<Student> patchDocument)
        {
            if (patchDocument == null || id <= 0)
            {
                return BadRequest();
            }
            var existingStudent = _IstudentRepository.GetStudentsByID(id);
            if (existingStudent == null)
            {
                return NotFound($"The student with id {id} not found");
            }
            var update = _IstudentRepository.UpdateStudent(existingStudent,patchDocument);
            if (update == 1)
            {
                return Ok(update);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
