using GameFinder.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GameFinder.Controllers
{
    public class RatingController : ApiController
    {
        private readonly GameFinderDbContext _context = new GameFinderDbContext();
        [HttpPost]

        public async Task<IHttpActionResult> CreateRating([FromBody] Rating model)
        {
            if (model is null)
                return BadRequest("Your request body cannot be empty");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var gameEntity = await _context.Game.FindAsync(model.GameID);
            if (gameEntity is null)
                return BadRequest($"The target game with the ID of {model.GameID} does not exist.");

            gameEntity.Ratings.Add(model);
            if (await _context.SaveChangesAsync() == 1)
                return Ok($"You rated game {gameEntity.GameTitle} Successfully!");
            return InternalServerError();
        }

        [HttpGet]

        public async Task<IHttpActionResult> GetByRating([FromUri]int rating)
        {
            

            var listOfGames = await _context.Game.Include(x => x.Ratings).ToListAsync();
            var listOfFilteredGames = listOfGames?.Where(x => x.Rating == rating) ?? new List<Game>();

            return Ok(listOfFilteredGames);
        }


    }
}
