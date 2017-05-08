using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Logging.Sample.Web.Controllers
{
    [Route("api/[controller]")]
    public class LoggingController : Controller
    {
        private readonly ILogger<LoggingController> _logger;

        public LoggingController(ILogger<LoggingController> logger)
        {
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var testMessage = "Logging example test";
            _logger.LogInformation(testMessage);

            return Ok(testMessage);
        }

       
    }
}
