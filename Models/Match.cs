using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookmakerAPI.Models
{
    public class Match
    {
        public int MatchId { get; set; }

        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MatchDate { get; set; }

        public int FirstTeamId { get; set; }

        public int SecondTeamId { get; set; }
        public int FirstTeamScore { get; set; }

        public int SecondTeamScore { get; set; }

        [JsonIgnore]
        public Team Team { get; set; }


    }
}
