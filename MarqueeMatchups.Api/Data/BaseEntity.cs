using System.ComponentModel.DataAnnotations;

namespace MarqueeMatchups.Api.Data
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
    }
}
