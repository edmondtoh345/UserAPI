using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class TokenGeneratorService : ITokenGeneratorService
    {
        public string GenerateToken(string email)
        {
            // Claim = The info you want to add/transfer to Json
            var claim = new[]
            {
                new Claim("email", email),
                //new Claim("role", role),
            };

            // Need to convert your secret key into bytes and then encrypt the secret key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("code_crusaders_secret_key_for_user"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Creating the token using claim and creds
            // Can give any names to issuer and audience
            var token = new JwtSecurityToken(
                issuer: "authapi",
                audience: "userapi",
                claims: claim,
                expires: System.DateTime.Now.AddMinutes(20),
                // Every token generated is valid for 20 minutes
                signingCredentials: creds
            );

            var response = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
            };

            return JsonConvert.SerializeObject(response);
        }
    }
}
