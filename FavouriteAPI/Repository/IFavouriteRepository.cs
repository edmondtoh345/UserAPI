using FavouriteAPI.Models;

namespace FavouriteAPI.Repository
{
    public interface IFavouriteRepository
    {
        List<Favourite> GetUserFavourites (string email);
        Favourite GetFavByID (int id);
        void AddFav (string email, Favourite fav);
        void UpdateFav (string email, int id, Favourite fav);
        void DeleteFav (int id);
    }
}
