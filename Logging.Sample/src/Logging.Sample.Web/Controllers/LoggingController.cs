using System;
using System.Reflection.Metadata;
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
            var random = new Random().Next(0,1000);
            var testMessage = $"Logging example test, with random number: {random}";
            
            _logger.LogInformation("Logging example test, with random number: {random}",random);

            return Ok(testMessage);
        }

       
    }
}
