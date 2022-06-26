using AutoMapper;
using FestivalApp.Domain.Interfaces;
using FestivalApp.Core.Models;
using FestivalApp.Core.Interfaces;

namespace FestivalApp.Core.Queries.GetFestival
{
    public class GetFestivalByIdQueryHandler : IQueryHandler<GetFestivalByIdQuery, FestivalModel>
    {
        private readonly IFestivalRepository _festivalRepository;
        private readonly IMapper _mapper;

        public GetFestivalByIdQueryHandler(IFestivalRepository festivalRepository, IMapper mapper)
        {
            _festivalRepository = festivalRepository;
            _mapper = mapper;
        }

        public async Task<FestivalModel> Handle(GetFestivalByIdQuery request, CancellationToken cancellationToken)
        {
            var festivalEntity = await _festivalRepository.GetFestival(request.Id);

            return _mapper.Map<FestivalModel>(festivalEntity);
        }
    }
}
