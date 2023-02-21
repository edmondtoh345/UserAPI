using UserAPI.Models;

namespace UserAPI.Services
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(string email);
    }
}
