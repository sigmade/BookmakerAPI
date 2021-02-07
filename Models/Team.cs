using Newtonsoft.Json;
using System.Collections.Generic;

namespace BookmakerAPI.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        [JsonIgnore]
        public List<Player> Players { get; set; }
        public List<Match> Matches { get; set; }
    }
}
