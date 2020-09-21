using System;

namespace FestivalApp.API.Dtos
{
  public class RentalForListDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime Created { get; set; }
    public int UserId { get; set; }
    public int FestivalId { get; set; }
    public string ThumbnailUrl { get; set; }
  }
}