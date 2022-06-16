using FestivalApp.Core.Commands.AddFestival;
using FestivalApp.Core.Commands.LikeFestival;
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
    }
}
