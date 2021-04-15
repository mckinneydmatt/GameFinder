using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models
{
    public class Game
    {
        public enum MaturityRating {E =1, E10, T, M }
        public enum Genre {Action =1, RPG, Shooter, Horror, Mystery, Puzzle, Moba }

        [Key]
        public int ID { get; set; }

        [Required]
        public string GameTitle { get; set; }
        public virtual List<Game> GameTitles { get; set; }
        public bool IsSinglePlayer { get; set; }

        // [Required]
        public Genre GameGenre { get; set; }

       // [Required]
        public MaturityRating MatRating { get; set; }

    }
}
