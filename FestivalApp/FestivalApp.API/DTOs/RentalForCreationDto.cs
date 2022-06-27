using System.ComponentModel.DataAnnotations;

namespace FestivalApp.API.DTOs
{
    public class RentalForCreationDto
    {
        public string Name { get; set; }

        public string County { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string? Description { get; set; }

        public int Price { get; set; }

        public int FestivalId { get; set; }
    }
}