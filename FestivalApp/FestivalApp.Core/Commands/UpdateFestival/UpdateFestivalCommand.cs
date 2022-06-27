using FestivalApp.Core.Interfaces;
using FestivalApp.Core.Models;
using MediatR;

namespace FestivalApp.Core.Commands.UpdateFestival
{
    public class UpdateFestivalCommand : ICommand<FestivalModel>
    {
        public int Id { get; set; }

        public FestivalUpdateModel FestivalUpdateModel { get; set; }

        public UpdateFestivalCommand(int id, FestivalUpdateModel festivalUpdateModel)
        {
            FestivalUpdateModel = festivalUpdateModel;
            Id = id;
        }
    }
}
