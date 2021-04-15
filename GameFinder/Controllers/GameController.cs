//using GameFinder.Data;
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
    public class GameController : ApiController
    {
        private readonly GameFinderDbContext _context = new GameFinderDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> AddGame([FromBody] Game model)
        {
            if (model is null)
                return BadRequest("Your request body cannot be empty.");
            if (ModelState.IsValid)
            {
                _context.Game.Add(model);
                int changeCounts = await _context.SaveChangesAsync();
                return Ok("You did it!");
            }
            return BadRequest(ModelState);
        }

        //[HttpGet]
        //public async Task<IHttpActionResult> GetAll()
        //{
        //Game game = await _context.Game.ToListAsync();
        //return Ok(game);
        //}

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Game> game = await _context.Game.ToListAsync();
            return Ok(game);
        }

    }
}
