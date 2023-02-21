using MongoDB.Driver;

namespace UserAPI.Models
{
    public class DataContext
    {
        MongoClient client;
        IMongoDatabase db;
        public DataContext()
        {
            var con = Environment.GetEnvironmentVariable("Mongo_DB");
            if (con == null)
            {
                client = new MongoClient("mongodb://localhost:27017");
            }
            else
            {
                client = new MongoClient(con);
            }
            db = client.GetDatabase("TransportAppDB");
        }

        public IMongoCollection<User> Users => db.GetCollection<User>("Users");
        public IMongoCollection<Favourite> Favourites => db.GetCollection<Favourite>("Favourites");
        public IMongoCollection<CreditCard> CreditCards => db.GetCollection<CreditCard>("CreditCards");
    }
}
