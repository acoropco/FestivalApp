using AutoMapper;
using FestivalApp.Core.Interfaces;
using MediatR;

namespace FestivalApp.Core.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IFestivalRepository _festivalRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IFestivalRepository festivalRepository, IMapper mapper)
        {
            _festivalRepository = festivalRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = await _festivalRepository.GetUser(request.Id);

            _mapper.Map(request.UserUpdateModel, userEntity);

            await _festivalRepository.SaveAll();

            return Unit.Value;
        }
    }
}
