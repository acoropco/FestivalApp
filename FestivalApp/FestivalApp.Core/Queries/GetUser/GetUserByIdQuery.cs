using FestivalApp.Core.Models;
using MediatR;

namespace FestivalApp.Core.Queries.GetUser
{
    public class GetUserByIdQuery : IRequest<UserModel>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
