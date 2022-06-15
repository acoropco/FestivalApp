namespace FestivalApp.Domain.Entities
{
    public class UserFestivalEntity
    {
        public int UserId { get; set; }

        public virtual UserEntity User { get; set; }

        public int FestivalId { get; set; }

        public virtual FestivalEntity Festival { get; set; }
    }
}