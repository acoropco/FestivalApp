using FestivalApp.Domain.Entities;

namespace FestivalApp.Core.Interfaces
{
    public interface IFestivalRepository
    {
        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveAll();

        Task<List<FestivalEntity>> GetFestivals();

        Task<FestivalEntity> GetFestival(int id);

        Task<UserEntity> GetUser(int id);

        Task<UserFestivalEntity> GetLike(int userId, int festivalId);

        Task<List<int>> GetLikedFestivalsId(int userId);

        Task<List<RentalEntity>> GetRentals();

        Task<RentalEntity> GetRental(int id);
    }
}