using FestivalApp.Core.Interfaces;
using FestivalApp.Domain.Models;

namespace FestivalApp.Core.Services
{
    internal class FestivalService : IFestivalService
    {
        private readonly IFestivalRepository _festivalRepository;

        public FestivalService(IFestivalRepository festivalRepository)
        {
            _festivalRepository = festivalRepository;
        }

        public Festival AddFestival(Festival festival)
        {
            throw new NotImplementedException();
        }

        public List<Festival> GetFestivals(int userId)
        {
            throw new NotImplementedException();
        }

        public void LikeFestival(int festivalId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
