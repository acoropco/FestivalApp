using FestivalApp.Core.Models;
using MediatR;

namespace FestivalApp.Core.Commands.AddFestival
{
    public class AddFestivalCommand : IRequest<int>
    {
        public Festival Payload { get; set; }

        public AddFestivalCommand(Festival festival)
        {
            Payload = festival;
        }
    }
}
