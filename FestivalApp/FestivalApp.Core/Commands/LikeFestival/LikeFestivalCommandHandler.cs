using FestivalApp.Core.Exceptions;
using FestivalApp.Core.Interfaces;
using FestivalApp.Domain.Entities;
using MediatR;

namespace FestivalApp.Core.Commands.LikeFestival
{
    public class LikeFestivalCommandHandler : IRequestHandler<LikeFestivalCommand, Unit>
    {
        private readonly IFestivalRepository _festivalRepository;

        public LikeFestivalCommandHandler(IFestivalRepository festivalRepository)
        {
            _festivalRepository = festivalRepository;
        }

        public async Task<Unit> Handle(LikeFestivalCommand request, CancellationToken cancellationToken)
        {
            var userEntity = await _festivalRepository.GetUser(request.UserId);
            var festivalEntity = await _festivalRepository.GetFestival(request.FestivalId);

            // TODO handle exception better
            if (userEntity == null || festivalEntity == null)
            {
                throw new NotFoundException();
            }

            var likeEntity = await _festivalRepository.GetLike(request.UserId, request.FestivalId);

            if (likeEntity != null)
            {
                _festivalRepository.Delete(likeEntity);
            }
            else
            {
                likeEntity = new UserFestival()
                {
                    User = userEntity,
                    Festival = festivalEntity,
                    UserId = request.UserId,
                    FestivalId = request.FestivalId
                };
                _festivalRepository.Add(likeEntity);
            }

            await _festivalRepository.SaveAll();
            
            return Unit.Value;
        }
    }
}
