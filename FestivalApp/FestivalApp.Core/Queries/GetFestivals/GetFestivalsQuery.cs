using FestivalApp.Core.Models;
using MediatR;

namespace FestivalApp.Core.Queries.GetFestivals
{
    public class GetFestivalsQuery : IRequest<List<Festival>>
    {
        public int UserId { get; set; }

        public GetFestivalsQuery(int userId)
        {
            UserId = userId;
        }
    }
}
