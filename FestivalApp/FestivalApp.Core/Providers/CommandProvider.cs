using FestivalApp.Core.Commands.AddFestival;
using FestivalApp.Core.Commands.AddRental;
using FestivalApp.Core.Commands.LikeFestival;
using FestivalApp.Core.Commands.UpdateFestival;
using FestivalApp.Core.Commands.UpdateRental;
using FestivalApp.Core.Commands.UpdateUser;
using FestivalApp.Core.Interfaces;
using FestivalApp.Core.Models;

namespace FestivalApp.Core.Providers
{
    public class CommandProvider : ICommandProvider
    {
        public AddFestivalCommand AddFestivalCommand(FestivalModel festival)
        {
            return new AddFestivalCommand(festival);
        }

        public LikeFestivalCommand LikeFestivalCommand(int festivalId, int userId)
        {
            return new LikeFestivalCommand(festivalId, userId);
        }

        public AddRentalCommand AddRentalCommand(int userId, RentalModel rental)
        {
            return new AddRentalCommand(userId, rental);
        }

        public UpdateUserCommand UpdateUserCommand(int id, UserUpdateModel userUpdateModel)
        {
            return new UpdateUserCommand(id, userUpdateModel);
        }

        public UpdateFestivalCommand UpdateFestivalCommand(int id, FestivalUpdateModel festivalUpdateModel)
        {
            return new UpdateFestivalCommand(id, festivalUpdateModel);
        }

        public UpdateRentalCommand UpdateRentalCommand(int id, int userId, RentalUpdateModel rentalUpdateModel)
        {
            return new UpdateRentalCommand(id, userId, rentalUpdateModel);
        }
    }
}
