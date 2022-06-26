using AutoMapper;
using FestivalApp.Core.Exceptions;
using FestivalApp.Domain.Interfaces;
using FestivalApp.Core.Models;
using FestivalApp.Core.Interfaces;

namespace FestivalApp.Core.Queries.GetRental
{
    public class GetRentalByIdQueryHandler : IQueryHandler<GetRentalByIdQuery, RentalModel>
    {
        private readonly IFestivalRepository _festivalRepositorry;
        private readonly IMapper _mapper;

        public GetRentalByIdQueryHandler(IFestivalRepository festivalRepositorry, IMapper mapper)
        {
            _festivalRepositorry = festivalRepositorry;
            _mapper = mapper;
        }

        public async Task<RentalModel> Handle(GetRentalByIdQuery request, CancellationToken cancellationToken)
        {
            var rentalEntity = await _festivalRepositorry.GetRental(request.Id);
            
            if (rentalEntity == null)
            {
                throw new NotFoundException($"Rental with ID: {request.Id} was not found");
            }

            return _mapper.Map<RentalModel>(rentalEntity);
        }
    }
}
