using FestivalApp.Core.Interfaces;
using FestivalApp.Core.Models;

namespace FestivalApp.Core.Queries.GetUser
{
    public class GetUserByIdQuery : IQuery<UserModel>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
