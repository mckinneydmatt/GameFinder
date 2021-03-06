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

        [Key]
        public int ID { get; set; }

        [Required]
        public string GameTitle { get; set; }


        //[Required]
        public string GenreName { get; set; }

        //[Required]
        public string MaturityRating { get; set; }

        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();

        public double Rating
        {
            get
            {
                double totalAverageRating = 0;
                foreach(var rating in Ratings)
                {
                    totalAverageRating += rating.AverageRating;
                }
                return Ratings.Count > 0
                    ? Math.Round(totalAverageRating / Ratings.Count, 2)
                    : 0;
            }
        }

        public virtual List<Game> GameTitles { get; set; }
        public bool IsSinglePlayer { get; set; }

        // [Required]
     

        public virtual List<Genre> Genres { get; set; }
       // [Required]
       // public Genre GameGenre { get; set; }
        public int GameGenreId { get; set; }

       


       // [Required]
       


    }
}
