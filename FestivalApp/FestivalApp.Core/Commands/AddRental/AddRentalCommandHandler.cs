using AutoMapper;
using FestivalApp.Domain.Interfaces;
using FestivalApp.Core.Models;
using MediatR;

namespace FestivalApp.Core.Commands.AddRental
{
    public class AddRentalCommandHandler : IRequestHandler<AddRentalCommand, int>
    {
        private readonly IFestivalRepository _festivalRepository;
        private readonly IMapper _mapper;

        public AddRentalCommandHandler(IFestivalRepository festivalRepository, IMapper mapper)
        {
            _festivalRepository = festivalRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddRentalCommand request, CancellationToken cancellationToken)
        {
            var rentalEntity = _mapper.Map<RentalModel>(request.Rental);
            rentalEntity.Created = DateTime.Now;

            _festivalRepository.Add(rentalEntity);

            await _festivalRepository.SaveAll();

            return rentalEntity.Id;
        }
    }
}
