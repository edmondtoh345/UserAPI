using UserAPI.Exceptions;
using UserAPI.Models;
using UserAPI.Repository;

namespace UserAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repo;
        public UserService(IUserRepository repo)
        {
            this.repo = repo;
        }

        public bool Login(string email, string password)
        {
            if (repo.GetUserByEmail(email) == null)
            {
                throw new UserNotFoundException($"User with Email: {email} does not exists!");
            }
            else if (!repo.Login(email, password))
            {
                throw new InvalidCredentialsException("Invalid Password");
            }
            return repo.Login(email, password);
        }

        public User Register(User user)
        {
            if (repo.GetUserByEmail(user.Email) != null)
            {
                throw new UserAlreadyExistsException($"User with Email: {user.Email} already exists!");
            }
            return repo.Register(user);
        }

        public Cred ResetPassword(string email)
        {
            if (repo.GetUserByEmail(email) == null)
            {
                throw new UserNotFoundException($"User with Email: {email} does not exists!");
            }
            return repo.ResetPassword(email);
        }

        public void UpdateUser(string email, User user)
        {
            repo.UpdateUser(email, user);
        }
    }
}
