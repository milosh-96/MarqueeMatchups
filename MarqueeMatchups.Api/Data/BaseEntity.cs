using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarqueeMatchups.Api.Data
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTimeOffset CreatedOn { get; set; } = DateTime.Now.ToUniversalTime();
       
        [NotMapped]
        public DateTime CreatedOnLocal
        {
            get { return this.CreatedOn.LocalDateTime; }
        }

    }
}
