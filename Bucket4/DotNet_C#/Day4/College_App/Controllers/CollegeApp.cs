using College_App.Data;
using College_App.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using College_App.MyLogger;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;

namespace College_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CollegeApp : ControllerBase
    {
        private readonly IMyLogger _mylogger;

        private readonly CollegeDBContext _dbcontext;

        public CollegeApp(IMyLogger MyLogger, CollegeDBContext dbcontext)
        {
            _mylogger = MyLogger;
            _dbcontext = dbcontext;
        }
        
        //STUDENT TABLE
        [HttpGet]
        [Route("Students")]
        public ActionResult<IEnumerable<studentDTO>> getstudents()
        {
            var students = _dbcontext.Student.ToList();
            /*var students = _dbcontext.Student.Select(s => new Student()
            {
                Name = s.Name,
                City = s.City
            }).ToList();*/
            return Ok(students);
        }

        [HttpGet("{id:Int}", Name = "getstudentsbyid")]
        public ActionResult<studentDTO> getstudentsbyid(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var students = _dbcontext.Student.Where(n => n.Id == id).FirstOrDefault();
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
        }


        [HttpPost("Create")]
        public ActionResult<studentDTO> CreateStudent([FromBody] Student Model)
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
            _dbcontext.Student.Add(studentnew);
            _dbcontext.SaveChanges();
            return Ok(Model);
        }

        [HttpDelete("Delete")]
        public bool deleteStudent(int id)
        {
            var deleting = _dbcontext.Student.Where(n => n.Id == id).FirstOrDefault();
            _dbcontext.Student.Remove(deleting);
            _dbcontext.SaveChanges();
            return true;
        }

        /*[HttpPatch]
        [Route("{id:int}/UpdateStudent")]
        public ActionResult updateStudentPartial(int id, [FromBody] JsonPatchDocument<studentDTO> patchDocument)
        {
            if (patchDocument == null || id <= 0)
            {
                return BadRequest();
            }
            var existingStudent = _dbcontext.Student.Where(s => s.Id == id).FirstOrDefault();
            if (existingStudent == null)
            {
                return NotFound($"The student with id {id} not found");
            }
            var student = new studentDTO()
            {
                name = existingStudent.Name,
                age = existingStudent.Age,
                email = existingStudent.Email,
                City = existingStudent.City
            };
            patchDocument.ApplyTo(student, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            existingStudent.Name = student.name;
            existingStudent.Age = student.age;
            existingStudent.Email = student.email;
            existingStudent.City = student.City;

            _dbcontext.SaveChanges();
            return NoContent();
        }
*/
/*
        //COURSE TABLE
        [HttpGet("Courses")]
        public ActionResult<IEnumerable<Course>> getCourses()
        {
            var courses = _dbcontext.Course.ToList();
            return Ok(courses);
        }

        [HttpGet("{id:Int}", Name = "getCourseById")]
        public ActionResult<Course> getCourseById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var courses = _dbcontext.Course.Where(n => n.Id == id).FirstOrDefault();
            var course = new course
            {
                Id = courses.Id,
                rank = courses.rank,
                CourseName = courses.CourseName
            };

            if (course == null)
            {
                return NotFound($"ID: {id} not found");
            }
            return Ok(courses);
        }

        [HttpPost("CreateCourse")]
        public ActionResult<Course> CreateCourse([FromBody] course Model)
        {
            if (Model == null)
            {
                return BadRequest();
            }
            course coursenew = new course
            {
                Id = Model.Id,
                rank = Model.rank,
                CourseName = Model.CourseName
            };
            _dbcontext.Course.Add(coursenew);
            _dbcontext.SaveChanges();
            return Ok(Model);
        }

        [HttpDelete("DeleteCourse")]
        public bool deleteCourse(int id)
        {
            var deleting = _dbcontext.Course.Where(n => n.Id == id).FirstOrDefault();
            _dbcontext.Course.Remove(deleting);
            _dbcontext.SaveChanges();
            return true;
        }

        [HttpPatch]
        [Route("{id:int}/UpdateCourse")]
        public ActionResult updateCourse(int id, [FromBody] JsonPatchDocument<course> patchDocument)
        {
            if (patchDocument == null || id <= 0)
            {
                return BadRequest();
            }
            var existingCourse = _dbcontext.Course.Where(s => s.Id == id).FirstOrDefault();
            if (existingCourse == null)
            {
                return NotFound($"The student with id {id} not found");
            }
            var courses = new course()
            {
                Id = existingCourse.Id,
                rank = existingCourse.rank,
                CourseName = existingCourse.CourseName
            };
            patchDocument.ApplyTo(courses,ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            existingCourse.Id = courses.Id;
            existingCourse.rank = courses.rank;
            existingCourse.CourseName = courses.CourseName;

            _dbcontext.SaveChanges();
            return NoContent();
        }*/

        /*
        [HttpGet]
        [Route("All")]
        public ActionResult<IEnumerable<studentDTO>> getstudents()
        {
            var students = collegeRepository.student.Select(s => new studentDTO()
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
            var students = collegeRepository.student.Where(n => n.studentID == id).FirstOrDefault();
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
            int newid = collegeRepository.student.LastOrDefault().studentID + 1;
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

        [HttpGet]
        [Route("getstudentsbyid")]
        public Student getstudentsbyid(int id)
        {
            return collegeRepository.students.Where(n => n.studentID == id).FirstOrDefault();
        
        }
        [HttpGet("{Name:Alpha}", Name = "getstudentsbyname")]
        public Student getstudentsbyname(string Name)
        {
            return collegeRepository.students.Where(n => n.name == Name).FirstOrDefault();
        }

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

        [HttpPut]
        public ActionResult<studentDTO> updateStudent([FromBody] studentDTO Model)
        {
            if (Model == null || Model.studentID<=0)
            {
                return BadRequest();
            }
            var existingStudent = collegeRepository.students.Where(s => s.studentID == Model.studentID).FirstOrDefault();
            if (existingStudent == null)
            {
                return NotFound($"The student with id {Model.studentID} not found");
            }
            existingStudent.name = Model.name;
            existingStudent.age = Model.age;
            existingStudent.email = Model.email;
            existingStudent.password = Model.password;
            existingStudent.reenterpassword = Model.reenterpassword;

            return Ok(existingStudent);
        }

        [HttpPatch]
        [Route("{id:int}/UpdatePartial")]
        public ActionResult updateStudentPartial(int id, [FromBody] JsonPatchDocument<studentDTO> patchDocument)
        {
            if (patchDocument == null || id <= 0)
            {
                return BadRequest();
            }
            var existingStudent = collegeRepository.students.Where(s => s.studentID == id).FirstOrDefault();
            if (existingStudent == null)
            {
                return NotFound($"The student with id {id} not found");
            }
            var studentDto = new studentDTO()
            {
                studentID = existingStudent.studentID,
                name = existingStudent.name,
                age = existingStudent.age,
                email = existingStudent.email
            };
            patchDocument.ApplyTo(studentDto, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            existingStudent.name = studentDto.name;
            existingStudent.age = studentDto.age;
            existingStudent.email = studentDto.email;

            return NoContent();
        }*/
    }
}
