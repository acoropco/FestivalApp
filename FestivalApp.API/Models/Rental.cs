using System.Collections.Generic;

namespace FestivalApp.API.Models
{
    public class Rental
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Location { get; set; }
      public virtual User User { get; set; }
      public int UserId { get; set; }
      public virtual Festival Festival { get; set; }
      public int FestivalId { get; set; }
      public virtual ICollection<RentalPhoto> RentalPhotos { get; set; }
    }
}