using System.ComponentModel.DataAnnotations.Schema;

namespace FavouriteAPI.Models
{
    public class Favourite
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Email { get; set; }
        public string FavName { get; set; }
        public string FavSource { get; set; }
        public string FavDestination { get; set; }
    }
}
