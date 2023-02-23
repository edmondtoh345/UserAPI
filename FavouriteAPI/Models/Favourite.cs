using Microsoft.EntityFrameworkCore;

namespace FavouriteAPI.Models
{
    public class Favourite
    {
        public int FavouriteID { get; set; }
        public string Email { get; set; }
        public string FavName { get; set; }
        public string FavSource { get; set; }
        public string FavDestination { get; set; }
    }
}
