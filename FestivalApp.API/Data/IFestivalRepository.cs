using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FestivalApp.API.Models;

namespace FestivalApp.API.Data
{
    public interface IFestivalRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<List<Festival>> GetFestivals();
         Task<Festival> GetFestival(int id);
         Task<User> GetUser(int id);
         Task<UserFestival> GetLike(int userId, int festivalId);
         Task<List<int>> GetLikedFestivalsId(int userId);
         Task<List<Rental>> GetRentals();
         Task<Rental> GetRental(int id);
    }
}