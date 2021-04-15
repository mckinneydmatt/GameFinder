using GameFinder.Models;
using GameFinder.Services;
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
    public class GenreController : ApiController
    {
        private readonly GameFinderDbContext _context = new GameFinderDbContext();

        


        //public IHttpActionResult Get(string genreName)
        //{
        //    GenreService genreService = CreateGenreService();
        //    var genre = genreService.GetGameByGenreName(genreName);
        //    return Ok(genre);
        //}

        private GenreService CreateGenreService()
        {
            var genreService = new GenreService();
            return genreService;
        }

        public async Task<IHttpActionResult> GetGameByGenreName([FromUri] string genre)
        {
            var listOfGames = await _context.Game.Include(x => x.Genres).ToListAsync();
            var listOfFilteredGames = listOfGames?.Where(x => x.GenreName == genre) ?? new List<Game>();
            return Ok(listOfFilteredGames);
        }



    }
}
