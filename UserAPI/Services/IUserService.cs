using UserAPI.Models;

namespace UserAPI.Services
{
    public interface IUserService
    {
        User Register (User user);
        bool Login (string email, string password);
        void UpdateUser (string email, User user);
        Cred ResetPassword (string email);
    }
}
