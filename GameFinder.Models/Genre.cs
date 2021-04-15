using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models
{
    public class Genre
    {
        [Key]
        public int GameGenreId { get; set; }

        public string GenreName { get; set; }

        [ForeignKey(nameof(Game))]
        public int GameID { get; set; }

        public virtual Game Game { get; set; }
        

        public string GameTitle { get; set; }

    }
}
