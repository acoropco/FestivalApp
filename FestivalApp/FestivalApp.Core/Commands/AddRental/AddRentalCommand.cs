using FestivalApp.Core.Interfaces;
using FestivalApp.Core.Models;

namespace FestivalApp.Core.Commands.AddRental
{
    public class AddRentalCommand : ICommand<int>
    {
        public int UserId { get; set; }

        public RentalModel Rental { get; set; }

        public AddRentalCommand(int userId, RentalModel rental)
        {
            UserId = userId;
            Rental = rental;
        }
    }
}
