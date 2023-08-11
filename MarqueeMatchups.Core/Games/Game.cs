using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarqueeMatchups.Core.Games
{
    public class Game : BaseEntity
    {
        public DateTimeOffset ScheduledAt { get; set; } = DateTimeOffset.UtcNow;

        [NotMapped]
        public DateTime ScheduledAtLocal
        {
            get { return ScheduledAt.LocalDateTime; }
        }
        public int SportId { get; set; }
        public virtual Sport? Sport { get; set; }

        [Required]
        public string Competition { get; set; } = "";

    }
}
