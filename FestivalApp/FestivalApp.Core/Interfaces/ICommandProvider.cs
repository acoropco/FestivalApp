﻿using FestivalApp.Core.Commands.AddFestival;
using FestivalApp.Core.Commands.AddRental;
using FestivalApp.Core.Commands.LikeFestival;
using FestivalApp.Core.Commands.UpdateFestival;
using FestivalApp.Core.Commands.UpdateRental;
using FestivalApp.Core.Commands.UpdateUser;
using FestivalApp.Core.Models;

namespace FestivalApp.Core.Interfaces
{
    public interface ICommandProvider
    {
        AddFestivalCommand AddFestivalCommand(FestivalModel festival);

        LikeFestivalCommand LikeFestivalCommand(int festivalId, int userId);

        AddRentalCommand AddRentalCommand(int userId, RentalModel rental);

        UpdateUserCommand UpdateUserCommand(int id, UserUpdateModel userUpdateModel);

        UpdateFestivalCommand UpdateFestivalCommand(int id, FestivalUpdateModel festivalUpdateModel);

        UpdateRentalCommand UpdateRentalCommand(int id, int userId, RentalUpdateModel rentalUpdateModel);
    }
}
