using System.ComponentModel.DataAnnotations;

namespace FestivalApp.API.Dtos
{
  public class RentalForCreationDto
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public string Location { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public int FestivalId { get; set; }
  }
}