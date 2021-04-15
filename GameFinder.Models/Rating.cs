using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Game))]
        public int GameID { get; set; }

        public virtual Game Game { get; set; }

        [Required, Range(0, 10)]
        public int GameVisuals { get; set; }

        [Required, Range(0, 10)]
        public int GamePlay { get; set; }

        [Required, Range(0, 10)]
        public int OverallEnjoyment { get; set; }

        [Required, Range(0, 10)]
        public int GameUI { get; set; }

        public int AverageRating
        {
            get
            {
                var totalScore = GameVisuals + GamePlay + OverallEnjoyment + GameUI;
                return totalScore / 4;
            }
        }

    }
}
