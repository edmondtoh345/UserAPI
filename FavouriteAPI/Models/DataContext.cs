using MongoDB.Driver;

namespace FavouriteAPI.Models
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
            db = client.GetDatabase("FavouriteDB");
        }

        public IMongoCollection<Favourite> Favourites => db.GetCollection<Favourite>("Favourites");
    }
}

