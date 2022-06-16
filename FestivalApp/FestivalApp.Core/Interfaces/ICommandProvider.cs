﻿using FestivalApp.Core.Commands.AddFestival;
using FestivalApp.Core.Commands.LikeFestival;
using FestivalApp.Core.Models;

namespace FestivalApp.Core.Interfaces
{
    public interface ICommandProvider
    {
        AddFestivalCommand AddFestivalCommand(FestivalModel festival);

        LikeFestivalCommand LikeFestivalCommand(int festivalId, int userId);
    }
}
