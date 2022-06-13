using FestivalApp.Core.Interfaces;
using FestivalApp.Core.Models;
using MediatR;

namespace FestivalApp.Core.Queries.GetFestivals
{
    public class GetFestivalsQueryHandler : IRequestHandler<GetFestivalsQuery, List<Festival>>
    {
        private readonly IFestivalRepository _festivalRepository;

        public GetFestivalsQueryHandler(IFestivalRepository festivalRepository)
        {
            _festivalRepository = festivalRepository;
        }

        public async Task<List<Festival>> Handle(GetFestivalsQuery request, CancellationToken cancellationToken)
        {
            var festivals = await _festivalRepository.GetFestivals();
            var festivalsLikedByUser = await _festivalRepository.GetLikedFestivalsId(request.UserId);

            foreach (var festival in festivals)
            {
                festival.IsLiked = festivalsLikedByUser.Contains(festival.Id);
            }

            return festivals;
        }
    }
}
