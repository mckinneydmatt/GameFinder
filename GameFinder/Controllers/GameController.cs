﻿//using GameFinder.Data;
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
        public async Task<IHttpActionResult> AddGame([FromBody] Models.Game model)
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

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Models.Game> game = await _context.Game.ToListAsync();
            return Ok(game);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetByID([FromUri] int id)
        {
            Models.Game game = await _context.Game.FindAsync(id);

            if(game != null)
            {
                return Ok(game);
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IHttpActionResult> EditGame([FromUri] int id, [FromBody] Models.Game editGame)
        {
            if(id != editGame?.ID)
            {
                return BadRequest("IDs do not match");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Models.Game game = await _context.Game.FindAsync(id);

            if (game is null)
                return NotFound();

            game.GameTitle = editGame.GameTitle;

            await _context.SaveChangesAsync();
            return Ok("Game was updated!");
            

            
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteGame([FromUri] int id)
        {
            Models.Game game = await _context.Game.FindAsync(id);
            if (game is null)
                return NotFound();
            _context.Game.Remove(game);

            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok("The game was deleted");
            }
            return InternalServerError();
        }
    }
}
