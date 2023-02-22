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
            if (d != null)
            {
                DeleteLocations(d.FavSource, d.FavDestination);
                db.Favourites.Remove(d);
                return db.SaveChanges();
            }
            return 0;

            /*if (d.FavSource != null)
            {
                db.Entry<Location>(d.FavSource).State = EntityState.Deleted;
            }
            if (d.FavDestination != null)
            {
                db.Entry<Location>(d.FavDestination).State = EntityState.Deleted;
            }
            db.Favourites.Remove(d);
            return db.SaveChanges();*/
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

        private void DeleteLocations(Location source, Location destination)
        {
            if (source != null && source.LocationID != null)
            {
                db.Locations.Remove(source);
            }
            if (destination != null && destination.LocationID != null)
            {
                db.Locations.Remove(destination);
            }
        }
    }
}
