using FavouriteAPI.Exceptions;
using FavouriteAPI.Models;
using FavouriteAPI.Repository;
using System.Data;

/*namespace FavouriteAPI.Services
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IFavouriteRepository repo;
        public FavouriteService(IFavouriteRepository repo)
        {
            this.repo = repo;
        }

        public void AddFav(string email, Favourite fav)
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
            repo.AddFav(email, fav);
        }

        public void DeleteFav(int id)
        {
            if (repo.GetFavByID(id) == null)
            {
                throw new FavNotFoundException($"Favourite with ID: {id} does not exists!");
            }
            repo.DeleteFav(id);
        }

        public List<Favourite> GetUserFavourites(string email)
        {
            return repo.GetUserFavourites(email);
        }

        public void UpdateFav(string email, int id, Favourite fav)
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
            repo.UpdateFav(email, id, fav);
        }
    }
}*/
