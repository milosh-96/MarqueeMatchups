namespace MarqueeMatchups.Api.Data
{
    public class Sport : BaseEntity
    {
        public virtual ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
