using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendmailAPI.Interfaces;
using SendmailAPI.Models;

namespace SendmailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly ITestClass _testClass;

        public EmailController(ITestClass testClass)
        {
            _testClass = testClass;
        }
        [HttpPost("Send mail")]
        public IActionResult Sendmail([FromQuery]EmailReceiver emailReceiver)
        {
            _testClass.Sending(emailReceiver);
            return Ok();
        }
    }
}
