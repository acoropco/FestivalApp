using FestivalApp.Core.Interfaces;
using FestivalApp.Core.Models;
using MediatR;

namespace FestivalApp.Core.Commands.UpdateRental
{
    public class UpdateRentalCommand : ICommand<RentalModel>
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public RentalUpdateModel RentalUpdateModel { get; set; }

        public UpdateRentalCommand(int id, int userId, RentalUpdateModel rentalUpdateModel)
        {
            Id = id;
            UserId = userId;
            RentalUpdateModel = rentalUpdateModel;
        }
    }
}
