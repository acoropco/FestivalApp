using FestivalApp.Core.Models;
using MediatR;

namespace FestivalApp.Core.Commands.AddRental
{
    public class AddRentalCommand : IRequest<int>
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
