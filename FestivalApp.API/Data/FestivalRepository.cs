using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FestivalApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FestivalApp.API.Data
{
  public class FestivalRepository : IFestivalRepository
  {
    private readonly DataContext _context;
    public FestivalRepository(DataContext context)
    {
      _context = context;
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
      var festivals = _context.Festivals.OrderBy(f => f.StartDate);

      return await festivals.ToListAsync();
    }

    public async Task<bool> SaveAll()
    {
      return await _context.SaveChangesAsync() > 0;
    }

    public async Task<UserFestival> GetLike(int userId, int festivalId)
    {
      return await _context.UserFestivals.FirstOrDefaultAsync(uf =>
        uf.UserId == userId && uf.FestivalId == festivalId);
    }

    public async Task<List<int>> GetLikedFestivalsId(int userId)
    {
      return await _context.UserFestivals.Where(uf => uf.UserId == userId).Select(f => f.FestivalId).ToListAsync();
    }

    public async Task<Rental> GetRental(int id)
    {
      return await _context.Rentals.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<List<Rental>> GetRentals()
    {
      var rentals  = _context.Rentals.OrderBy(r => r.Created);
      return await rentals.ToListAsync();
    }
  }
}