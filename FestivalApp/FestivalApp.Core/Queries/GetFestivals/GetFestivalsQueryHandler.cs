using AutoMapper;
using FestivalApp.Domain.Interfaces;
using FestivalApp.Core.Models;
using FestivalApp.Domain.Entities;
using FestivalApp.Core.Interfaces;

namespace FestivalApp.Core.Queries.GetFestivals
{
    public class GetFestivalsQueryHandler : IQueryHandler<GetFestivalsQuery, List<FestivalModel>>
    {
        private readonly IFestivalRepository _festivalRepository;
        private readonly IMapper _mapper;

        public GetFestivalsQueryHandler(IFestivalRepository festivalRepository, IMapper mapper)
        {
            _festivalRepository = festivalRepository;
            _mapper = mapper;
        }

        public async Task<List<FestivalModel>> Handle(GetFestivalsQuery request, CancellationToken cancellationToken)
        {
            var festivalEntities = await _festivalRepository.GetFestivals();
            var festivalsLikedByUser = await _festivalRepository.GetLikedFestivalsId(request.UserId);

            var festivals = _mapper.Map<List<Festival>, List<FestivalModel>>(festivalEntities);

            foreach (var festival in festivals)
            {
                festival.IsLiked = festivalsLikedByUser.Contains(festival.Id);
            }

            return festivals;
        }
    }
}
