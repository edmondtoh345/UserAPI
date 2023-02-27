using FavouriteAPI.Models;

namespace FavouriteAPI.Services
{
    public interface IFavouriteService
    {
        List<Favourite> GetUserFavourites(string email);
        void AddFav(string email, Favourite fav);
        void UpdateFav(string email, int id, Favourite fav);
        void DeleteFav(int id);
    }
}
