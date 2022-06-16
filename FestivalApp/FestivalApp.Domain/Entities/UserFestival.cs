namespace FestivalApp.Domain.Entities
{
    public class UserFestival
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int FestivalId { get; set; }

        public virtual Festival Festival { get; set; }
    }
}