using FavouriteAPI.Filters;
using FavouriteAPI.Models;
using FavouriteAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FavouriteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AppException]
    public class FavouriteController : ControllerBase
    {
        private readonly DataContext db;
        public FavouriteController(DataContext db)
        {
            this.db = db;
        }

        /*[HttpGet("favourites/{UserEmail}")]
        public ActionResult GetFavourites(string UserEmail)
        {
            return Ok(service.GetUserFavourites(UserEmail));
        }

        [HttpPost("favourites/{UserEmail}")]
        public IActionResult AddFav(string UserEmail, Favourite Fav)
        {
            service.AddFav(UserEmail, Fav);
            return StatusCode(201, new { message = "Favourite added successfully!", status = "201" });
        }

        [HttpDelete("favourites/{id}")]
        public IActionResult Delete(int id)
        {
            service.DeleteFav(id);
            return Ok(new { message = "Favourite deleted successfully" });
        }

        [HttpPut("favourites/{UserEmail}/{id}")]
        public IActionResult UpdateFav(string UserEmail, int id, Favourite Fav)
        {
            service.UpdateFav(UserEmail, id, Fav);
            return Ok(new { message = "Favourite updated successfully" });
        }*/

        [HttpPost]
        public IActionResult Post(Object doc)
        {
            var document = BsonSerializer.Deserialize<Favourite>(BsonDocument.Parse(doc.ToString()));
            db.Favourites.InsertOne(document);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var filter = Builders<Favourite>.Filter.Where(x => x.FavouriteID == id);
            db.Favourites.DeleteOne(filter);
            return Ok();
        }
    }
}
