using FestivalApp.Domain.Interfaces;
using FestivalApp.Infrastructure.Data;
using FestivalApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace FestivalApp.Infrastructure.Repositories
{
    public class FestivalRepository : IFestivalRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public FestivalRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Festival> GetFestival(int id)
        {
            return await _context.Festivals.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<Festival>> GetFestivals()
        {
            int id;
            return await _context.Festivals.OrderBy(f => f.StartDate).ToListAsync();
        }

        public async Task SaveAll()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<UserFestival> GetLike(int userId, int festivalId)
        {
            return await _context.UserFestivals.FirstOrDefaultAsync(uf => uf.UserId == userId && uf.FestivalId == festivalId);
        }

        public async Task<List<int>> GetLikedFestivalsId(int userId)
        {
            return await _context.UserFestivals.Where(uf => uf.UserId == userId).Select(uf => uf.FestivalId).ToListAsync();
        }

        public async Task<Rental> GetRental(int id)
        {
            return await _context.Rentals.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Rental>> GetRentals()
        {
            return await _context.Rentals.OrderBy(r => r.Created).ToListAsync();
        }
    }
}