namespace FestivalApp.Domain.Entities
{
    public class RentalPhoto
    {
      public int Id { get; set; }

      public string Url { get; set; }

      public bool IsMain { get; set; }

      public virtual Rental Rental { get; set; }

      public int RentalId { get; set; }
    }
}