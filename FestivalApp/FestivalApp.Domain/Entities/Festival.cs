namespace FestivalApp.Domain.Entities
{
    public class Festival
    {
      public int Id { get; set; }

      public string Name { get; set; }

      public string ImageUrl { get; set; }

      public DateTime StartDate { get; set; }

      public DateTime EndDate { get; set; }

      public string Street { get; set; }

      public string City { get; set; }

      public string TicketUrl { get; set; }

      public virtual ICollection<Rental> Rentals { get; set; }

      public virtual ICollection<UserFestival> UserFestivals { get; set; }
    }
}