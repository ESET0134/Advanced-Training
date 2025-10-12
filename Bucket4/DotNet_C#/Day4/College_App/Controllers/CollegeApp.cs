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
        [HttpGet]
        public IEnumerable<Student> getStudents()
        {
            return collegeRepository.students;
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

        [HttpGet("{id:Int}", Name = "getstudentsbyid")]
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
        }

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
