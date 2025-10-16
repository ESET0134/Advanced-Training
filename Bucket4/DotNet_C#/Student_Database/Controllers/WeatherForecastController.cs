using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Student> Get()
        {
            return _dbcontext.Students;
        }
    }
}
