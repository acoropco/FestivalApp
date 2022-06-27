using AutoMapper;
using FestivalApp.Core.Exceptions;
using FestivalApp.Core.Interfaces;
using FestivalApp.Core.Models;
using FestivalApp.Domain.Interfaces;

namespace FestivalApp.Core.Commands.UpdateRental
{
    public class UpdateRentalCommandHandler : ICommandHandler<UpdateRentalCommand, RentalModel>
    {
        private readonly IFestivalRepository _festivalRepository;
        private readonly IMapper _mapper;

        public UpdateRentalCommandHandler(IFestivalRepository festivalRepository, IMapper mapper)
        {
            _festivalRepository = festivalRepository;
            _mapper = mapper;
        }

        public async Task<RentalModel> Handle(UpdateRentalCommand request, CancellationToken cancellationToken)
        {
            var rentalEntity = await _festivalRepository.GetRental(request.Id);

            if (rentalEntity == null)
            {
                throw new NotFoundException($"Rental with ID: {request.Id} could not be found.");
            }

            if (rentalEntity.UserId != request.UserId)
            {
                throw new ForbiddenException("You are forbidden to do this action!");
            }

            _mapper.Map(request.RentalUpdateModel, rentalEntity);

            await _festivalRepository.SaveAll();

            return _mapper.Map<RentalModel>(rentalEntity);
        }
    }
}
