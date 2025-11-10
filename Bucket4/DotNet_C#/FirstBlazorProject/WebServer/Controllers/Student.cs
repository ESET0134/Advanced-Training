using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Student : ControllerBase
    {
        private readonly BlazorTutorialContext _blazorTutorialContext;
        public Student(BlazorTutorialContext blazorTutorialContext)
        {
            _blazorTutorialContext = blazorTutorialContext;
        }
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _blazorTutorialContext.Students.ToList();
            return Ok(students);
        }
    }
}
