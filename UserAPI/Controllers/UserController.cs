using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
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
        private readonly ITokenGeneratorService token;
        public UserController(IAdminService admin, IUserService service, ITokenGeneratorService token)
        {
            this.admin = admin;
            this.service = service;
            this.token = token;
        }

        // For User to register
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            service.Register(user);
            // var message = JsonConvert.SerializeObject("message")
            
            return StatusCode(201, new {message="User Registered Successfully!", status ="201"});
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
            string token = Request.Headers.Authorization;
            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                ValidAudience = "userapi",
                ValidIssuer = "authapi",
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("code_crusaders_secret_key_for_user"))
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken securitytoken;
            if (handler.CanReadToken(token))
            {
                var user = handler.ValidateToken(token, validationParameters, out securitytoken);
                return Ok(new { message = "Valid" });
            }
            return StatusCode(401, new {message = "Error", status = "401"});
        }

        // For User and Admin to update user details
        // [Authorize(Roles = "User, Admin")]
        [HttpPut("update/{UserEmail}")]
        public IActionResult UpdateUser(string UserEmail, User user)
        {
            service.UpdateUser(UserEmail, user);
            return Ok(new { message = "User details updated successfully!" });
        }

        // For User to reset password
        // [Authorize(Roles = "User")]
        [HttpPut("resetpassword")]
        public IActionResult ResetPassword(string UserEmail, User user)
        {
            service.ResetPassword(UserEmail, user);
            return Ok(new { message = "Password has been reset successfully!" });
        }

        // The below codes are for Administrator functions

        // For Admin to block user
        // [Authorize(Roles = "Admin")]
        [HttpPost("block/{UserEmail}")]
        public IActionResult BlockUser(string UserEmail, User user)
        {
            admin.BlockUser(UserEmail, user);
            return Ok(new { message = $"User with Email: {UserEmail} has been blocked successfully!" });
        }

        // For Admin to delete user
        // [Authorize(Roles = "Admin")]
        [HttpDelete("{UserEmail}")]
        public IActionResult DeleteUser(string UserEmail)
        {
            admin.DeleteUser(UserEmail);
            return Ok(new { message = $"User with Email: {UserEmail} deleted successfully!" });
        }

        // For Admin to get user details by email
        // [Authorize(Roles = "Admin")]
        [HttpGet("byemail/{UserEmail}")]
        public IActionResult GetUserByEmail(string UserEmail)
        {
            return Ok(admin.GetUserByEmail(UserEmail));
        }

        // For Admin to get all users
        // [Authorize(Roles = "Admin")]
        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            return Ok(admin.GetUsers());
        }
    }
}
