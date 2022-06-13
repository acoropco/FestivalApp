using FestivalApp.Domain.Models;

namespace FestivalApp.Core.Interfaces
{
    internal interface IFestivalService
    {
        public List<Festival> GetFestivals(int userId);

        public Festival AddFestival(Festival festival);

        public void LikeFestival(int festivalId, int userId);
    }
}
