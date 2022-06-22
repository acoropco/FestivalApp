using FestivalApp.Core.Queries.GetFestival;
using FestivalApp.Core.Queries.GetFestivals;
using FestivalApp.Core.Queries.GetRental;
using FestivalApp.Core.Queries.GetRentals;
using FestivalApp.Core.Queries.GetUser;
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

        public GetRentalByIdQuery GetRentalByIdQuery(int id)
        {
            return new GetRentalByIdQuery(id);
        }

        public GetRentalsQuery GetRentalsQuery()
        {
            return new GetRentalsQuery();
        }

        public GetUserByIdQuery GetUserByIdQuery(int id)
        {
            return new GetUserByIdQuery(id);
        }
    }
}
