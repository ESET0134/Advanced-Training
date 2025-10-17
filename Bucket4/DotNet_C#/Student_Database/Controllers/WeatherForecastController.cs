using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Database.Models;

namespace Student_Database.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly CollegeContext _dbcontext;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, CollegeContext dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }

        [HttpGet(Name = "GetStudentDetails")]
        public async Task<ActionResult<IEnumerable<Student>>> getStudents()
        {
            var student = await _dbcontext.Students.ToListAsync();
            var students = _dbcontext.Students.Select(s => new Student()
            {
                Id = s.Id,
                Name = s.Name,
                Age = s.Age,
                Email = s.Email
            }).ToListAsync();
            return Ok(student);
        }

        /*[HttpGet("{id:Int}", Name = "getstudentsbyid")]
        public ActionResult<IEnumerable<Student>> getstudentsbyid(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var students = _dbcontext.Students.Where(n => n.Id == id).FirstOrDefault();
            var student = new Student
            {
                Id = students.Id,
                Name = students.Name,
                Age = students.Age,
                Email = students.Email
            };

            if (student == null)
            {
                return NotFound($"ID: {id} not found");
            }
            return Ok(students);
        }*/
    }
}
