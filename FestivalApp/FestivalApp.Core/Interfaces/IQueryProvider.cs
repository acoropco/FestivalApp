﻿using FestivalApp.Core.Queries.GetFestival;
using FestivalApp.Core.Queries.GetFestivals;
using FestivalApp.Core.Queries.GetRental;
using FestivalApp.Core.Queries.GetRentals;

namespace FestivalApp.Core.Interfaces
{
    public interface IQueryProvider
    {
        GetFestivalsQuery GetFestivalsQuery(int userId);

        GetFestivalByIdQuery GetFestivalByIdQuery(int id);

        GetRentalsQuery GetRentalsQuery();

        GetRentalByIdQuery GetRentalByIdQuery(int id);
    }
}
