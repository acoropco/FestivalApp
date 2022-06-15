using AutoMapper;
using FestivalApp.Core.Interfaces;
using FestivalApp.Core.Models;
using FestivalApp.Domain.Entities;
using MediatR;

namespace FestivalApp.Core.Queries.GetFestivals
{
    public class GetFestivalsQueryHandler : IRequestHandler<GetFestivalsQuery, List<Festival>>
    {
        private readonly IFestivalRepository _festivalRepository;
        private readonly IMapper _mapper;

        public GetFestivalsQueryHandler(IFestivalRepository festivalRepository, IMapper mapper)
        {
            _festivalRepository = festivalRepository;
            _mapper = mapper;
        }

        public async Task<List<Festival>> Handle(GetFestivalsQuery request, CancellationToken cancellationToken)
        {
            var festivalEntities = await _festivalRepository.GetFestivals();
            var festivalsLikedByUser = await _festivalRepository.GetLikedFestivalsId(request.UserId);

            var festivals = _mapper.Map<List<FestivalEntity>, List<Festival>>(festivalEntities);

            foreach (var festival in festivals)
            {
                festival.IsLiked = festivalsLikedByUser.Contains(festival.Id);
            }

            return festivals;
        }
    }
}
