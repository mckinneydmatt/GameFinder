using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models
{
    public class GenreCreate
    {
        public int GameGenreId { get; set; }

        [Required]
        public string GenreName { get; set; }
        public int ID { get; set; }
        public string GameTitle { get; set; }
    }
}
