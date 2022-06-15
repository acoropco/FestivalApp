using FestivalApp.Core.Queries.GetFestival;
using FestivalApp.Core.Queries.GetFestivals;
using IQueryProvider = FestivalApp.Core.Interfaces.IQueryProvider;

namespace FestivalApp.Core.Providers
{
    public class QueryProvider : IQueryProvider
    {
        public GetFestivalByIdQuery GetFestivalByIdQuery(int id)
        {
            return new GetFestivalByIdQuery(id);
        }

        public GetFestivalsQuery GetFestivalsQuery(int userId)
        {
            return new GetFestivalsQuery(userId);
        }
    }
}
