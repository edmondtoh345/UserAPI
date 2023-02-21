using FavouriteAPI.Models;

namespace FavouriteAPI.Repository
{
    public interface IFavouriteRepository
    {
        List<Favourite> GetAllFavourites(string email);
        int AddFav (Favourite fav);
        int UpdateFav (int id, Favourite fav);
        int DeleteFav(int id);
    }
}
