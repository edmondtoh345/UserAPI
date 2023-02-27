using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FavouriteAPI.Models
{
    public class Favourite
    {
        [BsonId]
        public string FavouriteID { get; set; } = Guid.NewGuid().ToString();
        public dynamic? Document { get; set; }
    }
}
