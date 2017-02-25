using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BasketBallGamesCapture.Models
{
    public class HistoryModel
    {
        [Key]
        public string Id { get; set;}

        [Required]
        public string HomeTeamName { get; set; }

        [Required]
        public string VisitTeamName { get; set; }

        [Required]
        public string GamesTime { get; set; }

    }
}