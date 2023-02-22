using FavouriteAPI.Models;

namespace FavouriteAPI.Repository
{
    public interface IFavouriteRepository
    {
        List<Favourite> GetUserFavourites (string email);
        Favourite GetFavByID (int id);
        int AddFav (string email, Favourite fav);
        int UpdateFav (string email, int id, Favourite fav);
        int DeleteFav (int id);
    }
}
