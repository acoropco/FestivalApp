using System.ComponentModel.DataAnnotations;

namespace FestivalApp.API.Dtos
{
  public class RentalForCreationDto
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public string County { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Street { get; set; }
    public string Description { get; set; }
    [Required]
    public int Price { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public int FestivalId { get; set; }
  }
}