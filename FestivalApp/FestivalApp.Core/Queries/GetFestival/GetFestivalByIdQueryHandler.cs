using AutoMapper;
using FestivalApp.Core.Interfaces;
using FestivalApp.Core.Models;
using MediatR;

namespace FestivalApp.Core.Queries.GetFestival
{
    public class GetFestivalByIdQueryHandler : IRequestHandler<GetFestivalByIdQuery, Festival>
    {
        private readonly IFestivalRepository _festivalRepository;
        private readonly IMapper _mapper;

        public GetFestivalByIdQueryHandler(IFestivalRepository festivalRepository, IMapper mapper)
        {
            _festivalRepository = festivalRepository;
            _mapper = mapper;
        }

        public async Task<Festival> Handle(GetFestivalByIdQuery request, CancellationToken cancellationToken)
        {
            var festivalEntity = await _festivalRepository.GetFestival(request.Id);

            return _mapper.Map<Festival>(festivalEntity);
        }
    }
}
