using FestivalApp.Core.Queries.GetFestivals;
using IQueryProvider = FestivalApp.Core.Interfaces.IQueryProvider;

namespace FestivalApp.Core.Providers
{
    public class QueryProvider : IQueryProvider
    {
        public GetFestivalsQuery GetFestivalsQuery(int userId)
        {
            return new GetFestivalsQuery(userId);
        }
    }
}
