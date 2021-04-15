using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models
{
    public class GenreDetail
    {
        public int GameGenreId { get; set; }
        public string GenreName { get; set; }
        public int GameID { get; set; }
        public string GameTitle { get; set; }
    }
}
