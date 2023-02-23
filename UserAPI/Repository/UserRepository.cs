using MongoDB.Driver;
using UserAPI.Models;

namespace UserAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext db;
        public UserRepository(DataContext db)
        {
            this.db = db;
        }

        public User GetUserByEmail(string email)
        {
            return db.Users.Find(x => x.Email == email).FirstOrDefault();
        }

        public bool Login(string email, string password)
        {
            return db.Users.Find(x => x.Email == email && x.Password == password).Any();
        }

        public User Register(User user)
        {
            db.Users.InsertOne(user);
            return user;
        }

        public Cred ResetPassword(string email)
        {
            /*var filter = Builders<User>.Filter.Where(x => x.Email == email);
            var update = Builders<User>.Update
                .Set(x => x.Password, user.Password);
            db.Users.UpdateOne(filter, update);*/

            Cred c = new Cred();
            var filter = Builders<User>.Filter.Where(x => x.Email == email);
            c.Email = email;
            c.Password = Guid.NewGuid().ToString().Substring(0,13);
            var update = Builders<User>.Update
                .Set(x => x.Password, c.Password);
            db.Users.UpdateOne(filter, update);
            return c;
        }

        public void UpdateUser(string email, User user)
        {
            var filter = Builders<User>.Filter.Where(x => x.Email == email);
            var update = Builders<User>.Update
                .Set(x => x.FirstName, user.FirstName)
                .Set(x => x.LastName, user.LastName)
                .Set(x => x.Password, user.Password)
                .Set(x => x.Phone, user.Phone)
                .Set(x => x.Gender, user.Gender)
                .Set(x => x.DateOfBirth, user.DateOfBirth);
                //.Set(x => x.ProfilePic, user.ProfilePic);
            db.Users.UpdateOne(filter, update);
        }
    }
}
