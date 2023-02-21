using MongoDB.Driver;
using UserAPI.Models;

namespace UserAPI.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DataContext db;
        public AdminRepository(DataContext db)
        {
            this.db = db;
        }

        public void BlockUser(string email, User user)
        {
            var filter = Builders<User>.Filter.Where(x => x.Email == email);
            var update = Builders<User>.Update
                .Set(x => true, user.IsBlocked);
            db.Users.UpdateOne(filter, update);
        }

        public void DeleteUser(string email)
        {
            var filter = Builders<User>.Filter.Where(x => x.Email == email);
            db.Users.DeleteOne(filter);
        }

        public User GetUserByEmail(string email)
        {
            return db.Users.Find(x => x.Email == email).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return db.Users.Find(user => true).ToList(); ;
        }
    }
}
