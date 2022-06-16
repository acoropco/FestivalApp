namespace FestivalApp.API.DTOs
{
    public class UserProfileDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime Created { get; set; }

        public List<RentalForListDto> Rentals { get; set; }
    }
}