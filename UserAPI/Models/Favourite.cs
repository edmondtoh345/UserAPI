using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAPI.Models
{
    // Ignore this model (as of 21/2)
    public class Favourite
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Email { get; set; }
        public string FavName { get; set; }
        public string FavSource { get; set; }
        public string FavDestination { get; set; }
    }
}
