using Microsoft.AspNetCore.Mvc;

namespace Logging.Sample.Web.Controllers
{
    [Route("api/[controller]")]
    public class LoggingController : Controller
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var testMessage = "Logging example test";


            return Ok(testMessage);
        }

       
    }
}
