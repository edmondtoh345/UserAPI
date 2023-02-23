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
            else if (repo.GetUserFavourites(email).Where(x => x.FavSource == fav.FavSource
            && x.FavDestination == fav.FavDestination).Any())
            {
                throw new FavAlreadyExistsException("Favourite with the same route already exists!");
            }
            else if (fav.FavSource == fav.FavDestination)
            {
                throw new FavAlreadyExistsException("Source and destination are the same!");
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
            if(repo.GetUserFavourites(email).Where(x => x.FavName == fav.FavName).Any())
            {
                throw new FavAlreadyExistsException($"Favourite with Name: {fav.FavName} already exists!");
            }
            else if (repo.GetUserFavourites(email).Where(x => x.FavSource == fav.FavSource
            && x.FavDestination == fav.FavDestination).Any())
            {
                throw new FavAlreadyExistsException("Favourite with the same route already exists!");
            }
            else if (fav.FavSource == fav.FavDestination)
            {
                throw new FavAlreadyExistsException("Source and destination are the same!");
            }
            return repo.UpdateFav(email, id, fav);
        }
    }
}
