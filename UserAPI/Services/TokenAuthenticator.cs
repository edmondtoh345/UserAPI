using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace UserAPI.Services
{
    public class TokenAuthenticator : ITokenAuthenticator
    {
        public bool Authenticate(string token)
        {
            try
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("code_crusaders_secret_key_for_user"));
                var handler = new JwtSecurityTokenHandler();
                var validations = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,

                    ValidateIssuer = true,
                    ValidIssuer = "authapi",

                    ValidateAudience = true,
                    ValidAudience = "userapi"
                };
                handler.ValidateToken(token, validations, out var validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
