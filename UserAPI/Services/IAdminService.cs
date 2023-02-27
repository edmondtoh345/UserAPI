using UserAPI.Models;

namespace UserAPI.Services
{
    public interface IAdminService
    {
        List<User> GetUsers();
        User GetUserByEmail(string email);
        void BlockUser(string email, User user);
        void UnBlockUser(string email, User user);
        void DeleteUser(string email);
    }
}
