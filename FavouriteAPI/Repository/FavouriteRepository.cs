using FavouriteAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FavouriteAPI.Repository
{
    public class FavouriteRepository : IFavouriteRepository
    {
        private readonly DataContext db;
        public FavouriteRepository(DataContext db)
        {
            this.db = db;
        }

        public int AddFav(string email, Favourite fav)
        {
            db.Favourites.Add(fav);
            return db.SaveChanges();
        }

        public int DeleteFav(int id)
        {
            var d = db.Favourites.Find(id);
            db.Favourites.Remove(d);
            return db.SaveChanges();
        }

        public Favourite GetFavByID(int id)
        {
            return db.Favourites.Find(id);
        }

        public List<Favourite> GetUserFavourites(string email)
        {
            return db.Favourites.Where(x => x.Email == email).ToList();
        }

        public int UpdateFav(string email, int id, Favourite fav)
        {
            var u = db.Favourites.Find(id);
            u.FavName = fav.FavName;
            u.FavSource = fav.FavSource;
            u.FavDestination = fav.FavDestination;
            db.Entry<Favourite>(u).State = EntityState.Modified;
            return db.SaveChanges();
        }
    }
}
