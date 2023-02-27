using UserAPI.Models;

namespace UserAPI.Repository
{
    public interface IAdminRepository
    {
        List<User> GetUsers();
        User GetUserByEmail (string email);
        void BlockUser (string email, User user);
        void UnBlockUser (string email, User user);
        void DeleteUser (string email);
    }
}
