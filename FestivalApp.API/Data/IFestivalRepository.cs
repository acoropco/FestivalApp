using System.Threading.Tasks;

namespace FestivalApp.API.Data
{
    public interface IFestivalRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
    }
}