using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavouriteAPI.Models
{
    public class Favourite
    {
        public int FavouriteID { get; set; }
        public string Email { get; set; }
        public string FavName { get; set; }
        [ForeignKey("FavSource")]
        public int FavSourceID { get; set; }
        [ForeignKey("FavDestination")]
        public int FavDestinationID { get; set; }
        public virtual Location? FavSource { get; set; }
        public virtual Location? FavDestination { get; set; }
    }
}
