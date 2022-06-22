using AutoMapper;
using FestivalApp.Domain.Interfaces;
using FestivalApp.Core.Models;
using FestivalApp.Domain.Entities;
using MediatR;

namespace FestivalApp.Core.Queries.GetRentals
{
    public class GetRentalsQueryHandler : IRequestHandler<GetRentalsQuery, List<RentalModel>>
    {
        private readonly IFestivalRepository _festivalRepository;
        private readonly IMapper _mapper;

        public GetRentalsQueryHandler(IFestivalRepository festivalRepository, IMapper mapper)
        {
            _festivalRepository = festivalRepository;
            _mapper = mapper;
        }

        public async Task<List<RentalModel>> Handle(GetRentalsQuery request, CancellationToken cancellationToken)
        {
            var rentalEntities = await _festivalRepository.GetRentals();
            
            return _mapper.Map<List<Rental>, List<RentalModel>>(rentalEntities);
        }
    }
}
