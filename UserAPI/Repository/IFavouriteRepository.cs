namespace UserAPI.Repository
{
    // Ignore this Repo (as of 21/2)
    public interface IFavouriteRepository
    {
        void AddFavourite(string email);
        void UpdateFavourite(string email);
        void DeleteFavourite(string email);
    }
}
