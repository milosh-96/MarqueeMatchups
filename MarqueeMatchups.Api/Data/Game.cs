using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarqueeMatchups.Api.Data
{
    public class Game : BaseEntity
    {
        public DateTimeOffset ScheduledAt { get; set; } = DateTimeOffset.UtcNow;
        private DateTime scheduledAtUtc;

        [NotMapped]
        public DateTime ScheduledAtUtc
        {
            get { return this.ScheduledAt.UtcDateTime; }
        }

        public int SportId { get; set; }
        public virtual Sport? Sport { get; set; }

        [Required]
        public string Competition { get; set; } = "";
    }
}
