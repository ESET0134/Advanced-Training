using College_App.MyLogger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace College_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Logme : ControllerBase
    {
        private readonly IMyLogger _mylogger;

        public Logme(IMyLogger MyLogger)
        {
            _mylogger = MyLogger;
        }


        [HttpGet]
        public ActionResult index()
        {
            _mylogger.Log("index method started");


            return Ok();
        }

    }
}
