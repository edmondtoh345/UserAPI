using FavouriteAPI.Exceptions;
using FavouriteAPI.Models;
using FavouriteAPI.Repository;
using System.Data;

namespace FavouriteAPI.Services
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IFavouriteRepository repo;
        public FavouriteService(IFavouriteRepository repo)
        {
            this.repo = repo;
        }

        public int AddFav(string email, Favourite fav)
        {
            if (repo.GetUserFavourites(email).Where(x => x.FavName == fav.FavName).Any())
            {
                throw new FavAlreadyExistsException($"Favourite with Name: {fav.FavName} already exists!");
            }
            else if (repo.GetUserFavourites(email).Where(x => x.FavSource.Latitude == fav.FavSource.Latitude 
            && x.FavSource.Longitude == fav.FavSource.Longitude 
            && x.FavDestination.Latitude == fav.FavDestination.Latitude 
            && x.FavDestination.Longitude == fav.FavDestination.Longitude).Any())
            {
                throw new FavAlreadyExistsException($"Favourite with same source and destination already exists!");
            }
            return repo.AddFav(email, fav);
        }

        public int DeleteFav(int id)
        {
            if (repo.GetFavByID(id) == null)
            {
                throw new FavNotFoundException($"Favourite with ID: {id} does not exists!");
            }
            return repo.DeleteFav(id);
        }

        public List<Favourite> GetUserFavourites(string email)
        {
            return repo.GetUserFavourites(email);
        }

        public int UpdateFav(string email, int id, Favourite fav)
        {
            if (repo.GetUserFavourites(email).Where(x => x.FavName == fav.FavName).Any())
            {
                throw new FavAlreadyExistsException($"Favourite with Name: {fav.FavName} already exists!");
            }
            else if (repo.GetUserFavourites(email).Where(x => x.FavSource != null
            && x.FavSource.Latitude == fav.FavSource.Latitude
            && x.FavSource.Longitude == fav.FavSource.Longitude
            && x.FavDestination != null
            && x.FavDestination.Latitude == fav.FavDestination.Latitude
            && x.FavDestination.Longitude == fav.FavDestination.Longitude).Any())
            {
                throw new FavAlreadyExistsException($"Favourite with same source and destination already exists!");
            }
            return repo.UpdateFav(email, id, fav);
        }
    }
}
