using FestivalApp.Core.Interfaces;
using FestivalApp.Core.Models;

namespace FestivalApp.Core.Queries.GetFestivals
{
    public class GetFestivalsQuery : IQuery<List<FestivalModel>>
    {
        public int UserId { get; set; }

        public GetFestivalsQuery(int userId)
        {
            UserId = userId;
        }
    }
}
