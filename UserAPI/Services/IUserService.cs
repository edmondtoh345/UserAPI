using UserAPI.Models;

namespace UserAPI.Services
{
    public interface IUserService
    {
        User Register (User user);
        bool Login (string email, string password);
        void UpdateUser (string email, User user);
        void UpdateProfilePic(string email, string picture);
        Cred ResetPassword (string email);
    }
}
