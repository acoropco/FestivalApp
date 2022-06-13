namespace FestivalApp.Domain.Models
{
    public class RentalPhoto
    {
      public int Id { get; set; }

      public string Url { get; set; }

      public bool IsMain { get; set; }

      public int RentalId { get; set; }
    }
}