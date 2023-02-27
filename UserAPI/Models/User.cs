using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserAPI.Models
{
    public class User
    {
        [BsonId]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ProfilePic { get; set; } = "/Resources/Images/Default/Default_Profile_Pic.png";
        public string? Role { get; set; } = "User";
        public bool? IsBlocked { get; set; } = false;
    }
}
