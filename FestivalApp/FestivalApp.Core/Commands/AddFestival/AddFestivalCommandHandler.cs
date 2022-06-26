using FestivalApp.Domain.Interfaces;
using AutoMapper;
using FestivalApp.Domain.Entities;
using FestivalApp.Core.Interfaces;

namespace FestivalApp.Core.Commands.AddFestival
{
    public class AddFestivalCommandHandler : ICommandHandler<AddFestivalCommand, int>
    {
        private readonly IFestivalRepository _festivalRepository;
        private readonly IMapper _mapper;

        public AddFestivalCommandHandler(IFestivalRepository festivalRepository, IMapper mapper)
        {
            _festivalRepository = festivalRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddFestivalCommand request, CancellationToken cancellationToken)
        {
            var festivalEntity = _mapper.Map<Festival>(request.Festival);

            _festivalRepository.Add(festivalEntity);

            await _festivalRepository.SaveAll();
            
            return festivalEntity.Id;
        }
    }
}
