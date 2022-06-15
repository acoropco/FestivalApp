namespace FestivalApp.Domain.Entities
{
    public class RentalPhotoEntity
    {
      public int Id { get; set; }

      public string Url { get; set; }

      public bool IsMain { get; set; }

      public virtual RentalEntity Rental { get; set; }

      public int RentalId { get; set; }
    }
}