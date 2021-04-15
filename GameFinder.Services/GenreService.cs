using GameFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Services
{
    public class GenreService
    {
        public bool CreateGenre(GenreCreate model)
        {
            var entity =
                new Genre()
                {
                    GameGenreId = model.GameGenreId,
                    GenreName = model.GenreName,
                    ID = model.ID,
                    GameTitle = model.GameTitle
                };

            using (var ctx = new GameFinderDbContext())
            {
                ctx.Genres.Add(entity);
                return ctx.SaveChanges() == 1;

            }
        }

        public GenreDetail GetGameByGenreName(string genreName)
        {
            using (var ctx = new GameFinderDbContext())
            {
                var entity =
                    ctx
                        .Game
                        .Single(e => e.GenreName == genreName);
                return
                    new GenreDetail
                    {
                        ID = entity.ID,
                        GameTitle = entity.GameTitle,
                       
                        GameGenreId = entity.GameGenreId,
                       GenreName = entity.GenreName
                        
                    };
            }
        }

    }
}













