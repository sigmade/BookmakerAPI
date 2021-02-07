using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookmakerAPI.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string FullName { get; set; }
        public int TeamId { get; set; }

       //[JsonIgnore]
        public Team Team { get; set; }
    }
}
