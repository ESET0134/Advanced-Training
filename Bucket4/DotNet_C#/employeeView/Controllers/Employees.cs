using Microsoft.AspNetCore.Mvc;

namespace employeeView.Controllers
{
    public class Employees : Controller
    {
        public IActionResult Employee()
        {
            return View();
        }
    }
}
