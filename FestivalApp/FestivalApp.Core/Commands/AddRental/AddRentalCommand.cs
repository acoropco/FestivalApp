using FestivalApp.Core.Models;
using MediatR;

namespace FestivalApp.Core.Commands.AddRental
{
    public class AddRentalCommand : IRequest<int>
    {
        public RentalModel Rental { get; set; }

        public AddRentalCommand(RentalModel rental)
        {
            Rental = rental;
        }
    }
}
