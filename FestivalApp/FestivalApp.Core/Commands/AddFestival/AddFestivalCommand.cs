using FestivalApp.Core.Models;
using MediatR;

namespace FestivalApp.Core.Commands.AddFestival
{
    public class AddFestivalCommand : IRequest<int>
    {
        public FestivalModel Payload { get; set; }

        public AddFestivalCommand(FestivalModel festival)
        {
            Payload = festival;
        }
    }
}
