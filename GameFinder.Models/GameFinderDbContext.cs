//using GameFinder.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models
{
    public class GameFinderDbContext : DbContext
    {
        public GameFinderDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<Game> Game { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
