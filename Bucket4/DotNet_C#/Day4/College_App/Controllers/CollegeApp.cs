using College_App.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace College_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeApp : ControllerBase
    {
        /*[HttpGet]
        public IEnumerable<Student> getStudents()
        {
            return collegeRepository.students;
        }*/

        [HttpGet]
        [Route("All")]
        public ActionResult<IEnumerable<studentDTO>> getstudents()
        {
            var students = collegeRepository.students.Select(s => new studentDTO()
            {
                studentID = s.studentID,
                name = s.name,
                age = s.age,
                email = s.email,
                password = s.password,
                reenterpassword = s.reenterpassword
            });
            return Ok(students);
        }

        [HttpGet("{id:Int}", Name = "getstudentsbyid")]
        public ActionResult<studentDTO> getstudentsbyid(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var students = collegeRepository.students.Where(n => n.studentID == id).FirstOrDefault();
            var studentDTO = new studentDTO
            {
                studentID = students.studentID,
                name = students.name,
                age = students.age,
                email = students.email
            };

            if (studentDTO == null)
            {
                return NotFound($"ID: {id} not found");
            }
            return Ok(students);
        }

        [HttpPost("Create")]
        public ActionResult<studentDTO> CreateStudent([FromBody] studentDTO Model)
        {
            if (Model == null)
            {
                return BadRequest();
            }
            int newid = collegeRepository.students.LastOrDefault().studentID + 1;
            Student studentnew = new Student
            {
                studentID = newid,
                name = Model.name,
                age = Model.age,
                email = Model.email,
                password = Model.password,
                reenterpassword = Model.reenterpassword
            };
            collegeRepository.students.Add(studentnew);
            return Ok(Model);
        }

        /*[HttpGet("{id:Int}",Name = "getstudentsbyid")]
        //[HttpGet]
        //[Route("getstudentsbyid")]
        public Student getstudentsbyid(int id)
        {
            return collegeRepository.students.Where(n => n.studentID == id).FirstOrDefault();
        }*/

        //[HttpGet("{Name:Alpha}", Name = "getstudentsbyname")]
        /*
        [HttpGet]
        [Route ("getstudentsbyname")]
        public Student getstudentsbyname(string Name)
        {
            return collegeRepository.students.Where(n => n.name == Name).FirstOrDefault();
        }
        */

        [HttpDelete]
        public bool deleteStudent(int id)
        {
            var deleting = collegeRepository.students.Where(n => n.studentID == id).FirstOrDefault();
            collegeRepository.students.Remove(deleting);
            return true;
        }

        /*[HttpGet("{id:Int}", Name = "getstudentsbyid")]
        public ActionResult<IEnumerable<Student>> getstudentsbyid(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var students = collegeRepository.students.Where(n => n.studentID == id).FirstOrDefault();
            if (students == null)
            {
                return NotFound($"ID: {id} not found");
            }
            return Ok(students);
        }*/

        [HttpGet("{Name:Alpha}", Name = "getstudentsbyname")]
        public ActionResult<Student> getstudentsbyname(string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return BadRequest();
            }
            var students = collegeRepository.students.Where(n => n.name == Name).FirstOrDefault();
            if (students == null)
            {
                return NotFound($"Student: {Name} not found");
            }
            return Ok(students);
        }
    }
}
