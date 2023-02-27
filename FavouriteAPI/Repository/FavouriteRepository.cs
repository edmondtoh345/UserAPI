using FavouriteAPI.Models;
using MongoDB.Driver;

/*namespace FavouriteAPI.Repository
{
    public class FavouriteRepository : IFavouriteRepository
    {
        private readonly DataContext db;
        public FavouriteRepository(DataContext db)
        {
            this.db = db;
        }

        public void AddFav(string email, Favourite fav)
        {
            db.Favourites.InsertOne(fav);
        }

        public void DeleteFav(int id)
        {
            var filter = Builders<Favourite>.Filter.Where(x => x.FavouriteID == id);
            db.Favourites.DeleteOne(filter);
        }

        public Favourite GetFavByID(int id)
        {
            return db.Favourites.Find(x => x.FavouriteID == id).FirstOrDefault();
        }

        public List<Favourite> GetUserFavourites(string email)
        {
            return db.Favourites.Find(x => x.Email == email).ToList();
        }

        public void UpdateFav(string email, int id, Favourite fav)
        {
            var filter = Builders<Favourite>.Filter.Where(x => x.FavouriteID == id);
            var update = Builders<Favourite>.Update
                .Set(x => x.FavName, fav.FavName)
                .Set(x => x.FavSource, fav.FavSource)
                .Set(x => x.FavDestination, fav.FavDestination);
            db.Favourites.UpdateOne(filter, update);
        }
    }
}*/
