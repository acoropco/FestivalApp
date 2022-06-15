namespace FestivalApp.Domain.Entities
{
    public class RentalEntity
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string County { get; set; }

    public string City { get; set; }

    public string Street { get; set; }

    public string Description { get; set; }

    public int Price { get; set; }

    public DateTime Created { get; set; }

    public virtual UserEntity User { get; set; }

    public int UserId { get; set; }

    public virtual FestivalEntity Festival { get; set; }

    public int FestivalId { get; set; }

    public virtual ICollection<RentalPhotoEntity> RentalPhotos { get; set; }
  }
}