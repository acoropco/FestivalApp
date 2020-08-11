using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FestivalApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FestivalApp.API.Data {
  public class FestivalRepository : IFestivalRepository {
    private readonly DataContext _context;
    public FestivalRepository (DataContext context) {
      _context = context;
    }
    public void Add<T> (T entity) where T : class {
      _context.Add (entity);
    }

    public void Delete<T> (T entity) where T : class {
      _context.Remove (entity);
    }

    public async Task<Festival> GetFestival (int id) {
      return await _context.Festivals.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<List<Festival>> GetFestivals () {
      var festivals = _context.Festivals.OrderBy(f => f.StartDate);

      return await festivals.ToListAsync();
    }

    public async Task<bool> SaveAll () {
      return await _context.SaveChangesAsync () > 0;
    }

  }
}