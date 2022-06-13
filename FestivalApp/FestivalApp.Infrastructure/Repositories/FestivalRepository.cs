using FestivalApp.Core.Interfaces;
using FestivalApp.Infrastructure.Data;
using FestivalApp.Infrastructure.Entities;
using DomainModels = FestivalApp.Core.Models;
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

        public async Task<DomainModels.Festival> GetFestival(int id)
        {
            var festival = await _context.Festivals.FirstOrDefaultAsync(f => f.Id == id);

            return _mapper.Map<DomainModels.Festival>(festival);
        }

        public async Task<DomainModels.User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            return _mapper.Map<DomainModels.User>(user);
        }

        public async Task<List<DomainModels.Festival>> GetFestivals()
        {
            var festivals = await _context.Festivals.OrderBy(f => f.StartDate).ToListAsync();

            return _mapper.Map<List<Festival>, List<DomainModels.Festival>>(festivals);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<DomainModels.UserFestival> GetLike(int userId, int festivalId)
        {
            var userFestival = await _context.UserFestivals.FirstOrDefaultAsync(uf => uf.UserId == userId && uf.FestivalId == festivalId);

            return _mapper.Map<DomainModels.UserFestival>(userFestival);
        }

        public async Task<List<int>> GetLikedFestivalsId(int userId)
        {
            return await _context.UserFestivals.Where(uf => uf.UserId == userId).Select(f => f.FestivalId).ToListAsync();
        }

        public async Task<DomainModels.Rental> GetRental(int id)
        {
            var rental = await _context.Rentals.FirstOrDefaultAsync(r => r.Id == id);

            return _mapper.Map<DomainModels.Rental>(rental);
        }

        public async Task<List<DomainModels.Rental>> GetRentals()
        {
            var rentals = await _context.Rentals.OrderBy(r => r.Created).ToListAsync();

            return _mapper.Map<List<Rental>, List<DomainModels.Rental>>(rentals);
        }
    }
}