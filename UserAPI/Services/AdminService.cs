using UserAPI.Exceptions;
using UserAPI.Models;
using UserAPI.Repository;

namespace UserAPI.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository repo;
        public AdminService(IAdminRepository repo)
        {
            this.repo = repo;
        }

        public void BlockUser(string email, User user)
        {
            if (repo.GetUserByEmail(email) == null)
            {
                throw new UserNotFoundException($"User with Email: {email} does not exists!");
            }
            repo.BlockUser(email, user);
        }

        public void DeleteUser(string email)
        {
            if (repo.GetUserByEmail(email) == null)
            {
                throw new UserNotFoundException($"User with Email: {email} does not exists!");
            }
            repo.DeleteUser(email);
        }

        public User GetUserByEmail(string email)
        {
            if (repo.GetUserByEmail(email) == null)
            {
                throw new UserNotFoundException($"User with Email: {email} does not exists!");
            }
            return repo.GetUserByEmail(email);
        }

        public List<User> GetUsers()
        {
            return repo.GetUsers();
        }
    }
}
