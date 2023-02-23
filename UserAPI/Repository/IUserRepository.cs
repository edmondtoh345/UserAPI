using UserAPI.Models;

namespace UserAPI.Repository
{
    public interface IUserRepository
    {
        User Register (User user);
        bool Login (string email, string password);
        void UpdateUser (string email, User user);
        Cred ResetPassword (string email);
        User GetUserByEmail (string email);
    }
}
