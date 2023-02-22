using FavouriteAPI.Models;

namespace FavouriteAPI.Services
{
    public interface IFavouriteService
    {
        List<Favourite> GetUserFavourites(string email);
        int AddFav(string email, Favourite fav);
        int UpdateFav(string email, int id, Favourite fav);
        int DeleteFav(int id);
    }
}
