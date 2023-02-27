using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
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

        // DONE
        // For User to register
        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            service.Register(user);
            var em = user.Email;

            using (var httpClient = new HttpClient())
            {
                var requestData = new { email = em };
                var requestJson = JsonSerializer.Serialize(requestData);
                var requestContent = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"https://localhost:7202/api/Email/registered?email={em}", requestContent);

                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
            return StatusCode(201, new { message = "User registered successfully!", status = "201" });
        }

        //DONE
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
        [HttpPut("resetpassword")]
        public async Task<IActionResult> ResetPassword(string UserEmail)
        {
            service.ResetPassword(UserEmail);
            var pw = service.GetUserByEmail(UserEmail).Password;
            
            using (var httpClient = new HttpClient())
            {
                var requestData = new { email = UserEmail, password = pw };
                var requestJson = JsonSerializer.Serialize(requestData);
                var requestContent = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"https://localhost:7202/api/Email/newpassword?email={UserEmail}&password={pw}", requestContent);

                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
            return Ok(new { message = $"New password has been sent to {UserEmail}." });
        }


        // The below codes are for Administrator functions


        // For Admin to block user
        // [Authorize(Roles = "Admin")]
        [HttpPut("admin/block/{UserEmail}")]
        public async Task<IActionResult> BlockUser(string UserEmail, User user)
        {
            admin.BlockUser(UserEmail, user);

            using (var httpClient = new HttpClient())
            {
                var requestData = new { email = UserEmail };
                var requestJson = JsonSerializer.Serialize(requestData);
                var requestContent = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"https://localhost:7202/api/Email/blocked?email={UserEmail}", requestContent);

                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
            return Ok(new { message = $"User with Email: {UserEmail} has been blocked successfully!" });
        }

        // For Admin to unblock user
        // [Authorize(Roles = "Admin")]
        [HttpPut("admin/unblock/{UserEmail}")]
        public async Task<IActionResult> UnBlockUser(string UserEmail, User user)
        {
            admin.UnBlockUser(UserEmail, user);

            using (var httpClient = new HttpClient())
            {
                var requestData = new { email = UserEmail };
                var requestJson = JsonSerializer.Serialize(requestData);
                var requestContent = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"https://localhost:7202/api/Email/unblocked?email={UserEmail}", requestContent);

                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
            return Ok(new { message = $"User with Email: {UserEmail} has been unblocked successfully!" });
        }

        // For Admin to delete user
        // [Authorize(Roles = "Admin")]
        [HttpDelete("admin/delete/{UserEmail}")]
        public IActionResult DeleteUser(string UserEmail)
        {
            admin.DeleteUser(UserEmail);
            return Ok(new { message = $"User with Email: {UserEmail} deleted successfully!" });
        }

        // For User and Admin to get user details by email
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
