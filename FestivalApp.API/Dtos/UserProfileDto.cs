using System;
using System.Collections.Generic;
using FestivalApp.API.Models;

namespace FestivalApp.API.Dtos {
  public class UserProfileDto {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime Created { get; set; }
    public virtual ICollection<Rental> Rentals { get; set; }
  }
}