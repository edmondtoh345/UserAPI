using EmailAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService service;
        public EmailController(IEmailService service)
        {
            this.service = service;
        }

        // To send registered email
        [HttpPost("registered")]
        public IActionResult RegisteredEmail(string email)
        {
            service.RegisteredEmail(email);
            return Ok(new { message = "Registered Email sent successfully" });
        }

        // To send new password
        [HttpPost("newpassword")]
        public IActionResult ForgetPasswordEmail(string email, string password)
        {
            service.ForgetPasswordEmail(email, password);
            return Ok(new { message = "Email with new password sent successfully" });
        }

        // To send blocked email
        [HttpPost("blocked")]
        public IActionResult BlockedEmail(string email)
        {
            service.BlockedEmail(email);
            return Ok(new { message = "Blocked Email sent successfully" });
        }

        // To send unblocked email
        [HttpPost("unblocked")]
        public IActionResult UnblockedEmail(string email)
        {
            service.UnblockedEmail(email);
            return Ok(new { message = "Unblocked Email sent successfully" });
        }
    }
}
