using System;
using System.ComponentModel.DataAnnotations;

namespace FestivalApp.API.Dtos {
  public class FestivalForCreationDto {
    [Required]
    public string Name { get; set; }
    [Required]
    public string ImageUrl { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    [Required]
    public string Location { get; set; }
    [Required]
    public string City { get; set; }
    public string TicketUrl { get; set; }
  }
}