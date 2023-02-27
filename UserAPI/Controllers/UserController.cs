using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text;
using UserAPI.Filters;
using UserAPI.Models;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AppException]
    public class UserController : ControllerBase
    {
        private readonly IAdminService admin;
        private readonly IUserService service;
        private readonly ITokenAuthenticator authenticator;
        private readonly ITokenGeneratorService token;
        public UserController(IAdminService admin, IUserService service, ITokenAuthenticator authenticator, ITokenGeneratorService token)
        {
            this.admin = admin;
            this.service = service;
            this.token = token;
            this.authenticator = authenticator;
        }

        // For User to register
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            service.Register(user);
            // var message = JsonConvert.SerializeObject("message")
            
            return StatusCode(201, new {message="User registered successfully!", status ="201"});
        }

        // For User and Admin to login
        // [Authorize(Roles = "User, Admin")]
        [HttpPost("login")]
        public IActionResult Login(Cred user)
        {
            service.Login(user.Email, user.Password);
            return Ok(token.GenerateToken(user.Email));
        }

        // To Authenticate the Token
        [HttpPost("isauthenticated")]
        public IActionResult IsAuthenticated()
        {
            var authorizationHeader = Request.Headers["Authorization"];
            if (authorizationHeader.ToString().StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                var token = authorizationHeader.ToString().Substring("Bearer ".Length).Trim();
                if (authenticator.Authenticate(token))
                {
                    return Ok(true);
                }
            }
            return Unauthorized(false);
        }

        // For User and Admin to update user details
        // [Authorize(Roles = "User, Admin")]
        [HttpPut("updatedetails/{UserEmail}")]
        public IActionResult UpdateUser(string UserEmail, User user)
        {
            service.UpdateUser(UserEmail, user);
            return Ok(new { message = "User details updated successfully!" });
        }

        // For User to upload profile pic (but not updated)
        [HttpPost("profilepic"), DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Internal server error: {ex}" });
            }
        }

        // For User to update profile pic (in conjunction with upload profile pic)
        // [Authorize(Roles = "User, Admin")]
        [HttpPut("profilepic/{UserEmail}")]
        public IActionResult UpdateProfilePic(string UserEmail, string picture)
        {
            service.UpdateProfilePic(UserEmail, picture);
            return Ok(new { message = "User profile picture updated successfully!" });
        }

        // For User to reset password
        // [Authorize(Roles = "User")]
        [HttpPut("resetpassword")]
        public IActionResult ResetPassword(string UserEmail)
        {
            service.ResetPassword(UserEmail);
            return Ok(new { message = $"New password has been sent to {UserEmail}." });
        }


        // The below codes are for Administrator functions


        // For Admin to block user
        // [Authorize(Roles = "Admin")]
        [HttpPut("admin/block/{UserEmail}")]
        public IActionResult BlockUser(string UserEmail, User user)
        {
            admin.BlockUser(UserEmail, user);
            return Ok(new { message = $"User with Email: {UserEmail} has been blocked successfully!" });
        }

        // For Admin to delete user
        // [Authorize(Roles = "Admin")]
        [HttpDelete("admin/delete/{UserEmail}")]
        public IActionResult DeleteUser(string UserEmail)
        {
            admin.DeleteUser(UserEmail);
            return Ok(new { message = $"User with Email: {UserEmail} deleted successfully!" });
        }

        // For Admin to get user details by email
        // [Authorize(Roles = "Admin")]
        [HttpGet("admin/byemail/{UserEmail}")]
        public IActionResult GetUserByEmail(string UserEmail)
        {
            return Ok(admin.GetUserByEmail(UserEmail));
        }

        // For Admin to get all users
        // [Authorize(Roles = "Admin")]
        // [Authorize] // This is for testing purpose
        [HttpGet("admin/allusers")]
        public IActionResult GetAllUsers()
        {
            return Ok(admin.GetUsers());
        }
    }
}
