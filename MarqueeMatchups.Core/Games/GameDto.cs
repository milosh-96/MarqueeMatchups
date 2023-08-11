using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarqueeMatchups.Core.Games
{
    public class GameDto
    {
        public string Name { get; set; }
        public string ScheduledAt { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        public int SportId { get; set; }

        public string Competition { get; set; } = "";
    }
}
