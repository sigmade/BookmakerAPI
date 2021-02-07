
namespace BookmakerAPI.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string FullName { get; set; }
        public int TeamId { get; set; }

        public Team Team { get; set; }
    }
}
