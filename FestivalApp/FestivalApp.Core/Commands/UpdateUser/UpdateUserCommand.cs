using FestivalApp.Core.Interfaces;
using FestivalApp.Core.Models;
using MediatR;

namespace FestivalApp.Core.Commands.UpdateUser
{
    public class UpdateUserCommand : ICommand<Unit>
    {
        public int Id { get; set; }

        public UserUpdateModel UserUpdateModel { get; set; }

        public UpdateUserCommand(int id, UserUpdateModel userUpdateModel)
        {
            Id = id;
            UserUpdateModel = userUpdateModel;
        }
    }
}
