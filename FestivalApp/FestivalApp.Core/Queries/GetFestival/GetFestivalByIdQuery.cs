using FestivalApp.Core.Models;
using MediatR;

namespace FestivalApp.Core.Queries.GetFestival
{
    public class GetFestivalByIdQuery : IRequest<Festival>
    {
        public int Id { get; set; }

        public GetFestivalByIdQuery(int id)
        {
            Id = id;
        }
    }
}
