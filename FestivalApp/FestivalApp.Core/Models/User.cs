namespace FestivalApp.Core.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime Created { get; set; }

        public List<Rental> Rentals { get; set; }

        public List<UserFestival> UserFestivals { get; set; }
    }
}