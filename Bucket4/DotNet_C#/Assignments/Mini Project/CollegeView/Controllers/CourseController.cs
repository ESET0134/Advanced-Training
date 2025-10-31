using Microsoft.AspNetCore.Mvc;

namespace CollegeView.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
