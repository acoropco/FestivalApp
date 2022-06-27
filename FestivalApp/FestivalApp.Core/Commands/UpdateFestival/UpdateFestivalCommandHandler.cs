using AutoMapper;
using FestivalApp.Core.Exceptions;
using FestivalApp.Core.Interfaces;
using FestivalApp.Core.Models;
using FestivalApp.Domain.Interfaces;

namespace FestivalApp.Core.Commands.UpdateFestival
{
    public class UpdateFestivalCommandHandler : ICommandHandler<UpdateFestivalCommand, FestivalModel>
    {
        private readonly IFestivalRepository _festivalRepository;
        private readonly IMapper _mapper;

        public UpdateFestivalCommandHandler(IFestivalRepository festivalRepository, IMapper mapper)
        {
            _festivalRepository = festivalRepository;
            _mapper = mapper;
        }

        public async Task<FestivalModel> Handle(UpdateFestivalCommand request, CancellationToken cancellationToken)
        {
            var festivalEntity = await _festivalRepository.GetFestival(request.Id);

            if (festivalEntity == null)
            {
                throw new NotFoundException($"Festival with ID: {request.Id} could not be found");
            }

            _mapper.Map(request.FestivalUpdateModel, festivalEntity);

            await _festivalRepository.SaveAll();

            return _mapper.Map<FestivalModel>(festivalEntity);
        }
    }
}
