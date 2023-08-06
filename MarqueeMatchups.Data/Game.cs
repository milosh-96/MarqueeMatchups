using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarqueeMatchups.Data
{
    public class Game : BaseEntity
    {
        public DateTimeOffset ScheduledAt { get; set; } = DateTimeOffset.UtcNow;
     
        [NotMapped]
        public DateTime ScheduledAtLocal
        {
            get { return this.ScheduledAt.LocalDateTime; }
        }
        public int SportId { get; set; }
        public virtual Sport? Sport { get; set; }

        [Required]
        public string Competition { get; set; } = "";
    }
}
