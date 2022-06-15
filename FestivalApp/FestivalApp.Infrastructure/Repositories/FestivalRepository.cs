using FestivalApp.Core.Interfaces;
using FestivalApp.Infrastructure.Data;
using FestivalApp.Domain.Entities;
using FestivalApp.Core.Models;
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

        public async Task<FestivalEntity> GetFestival(int id)
        {
            return await _context.Festivals.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<UserEntity> GetUser(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<FestivalEntity>> GetFestivals()
        {
            return await _context.Festivals.OrderBy(f => f.StartDate).ToListAsync();
        }

        public async Task SaveAll()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<UserFestivalEntity> GetLike(int userId, int festivalId)
        {
            return await _context.UserFestivals.FirstOrDefaultAsync(uf => uf.UserId == userId && uf.FestivalId == festivalId);
        }

        public async Task<List<int>> GetLikedFestivalsId(int userId)
        {
            return await _context.UserFestivals.Where(uf => uf.UserId == userId).Select(f => f.FestivalId).ToListAsync();
        }

        public async Task<RentalEntity> GetRental(int id)
        {
            return await _context.Rentals.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<RentalEntity>> GetRentals()
        {
            return await _context.Rentals.OrderBy(r => r.Created).ToListAsync();
        }
    }
}