using FestivalApp.Core.Interfaces;
using FestivalApp.Core.Models;

namespace FestivalApp.Core.Commands.AddFestival
{
    public class AddFestivalCommand : ICommand<int>
    {
        public FestivalModel Festival { get; set; }

        public AddFestivalCommand(FestivalModel festival)
        {
            Festival = festival;
        }
    }
}
