using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace FavouriteAPI.Models
{
    public class DataContext: DbContext
    {

        public DataContext(DbContextOptions options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Favourite> Favourites { get; set; }
    }
}

