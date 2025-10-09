using College_App.Model;
using Microsoft.AspNetCore.Http;
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
    }
}
