﻿using FestivalApp.Core.Queries.GetFestivals;

namespace FestivalApp.Core.Interfaces
{
    public interface IQueryProvider
    {
        GetFestivalsQuery GetFestivalsQuery(int userId);
    }
}