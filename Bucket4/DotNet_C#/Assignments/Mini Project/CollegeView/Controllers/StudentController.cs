using Microsoft.AspNetCore.Mvc;

namespace CollegeView.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
