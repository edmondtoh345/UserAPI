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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Favourite>()
                .HasOne(f => f.FavSource)
                .WithMany()
                .HasForeignKey(f => f.FavSourceID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Favourite>()
                .HasOne(f => f.FavDestination)
                .WithMany()
                .HasForeignKey(f => f.FavDestinationID)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}

