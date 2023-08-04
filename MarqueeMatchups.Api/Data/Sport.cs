namespace MarqueeMatchups.Api.Data
{
    public class Sport : BaseEntity
    {
        public virtual ICollection<Game> Games { get; set; } = new List<Game>();
    }



    public enum SportValues
    {
        None = 0,
        Football = 1,
        Basketball = 2,
        Baseball = 3,
        Volleyball = 4,
        Tennis =5,
        Cricket =6 ,
        IceHockey = 7
    }
}
