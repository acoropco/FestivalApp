﻿using AutoMapper;
using FestivalApp.Core.Exceptions;
using FestivalApp.Domain.Interfaces;
using FestivalApp.Core.Models;
using FestivalApp.Core.Interfaces;

namespace FestivalApp.Core.Queries.GetUser
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserModel>
    {
        private readonly IFestivalRepository _festivalRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IFestivalRepository festivalRepository, IMapper mapper)
        {
            _festivalRepository = festivalRepository;
            _mapper = mapper;
        }

        public async Task<UserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userEntity = await _festivalRepository.GetUser(request.Id);

            if (userEntity == null)
            {
                throw new NotFoundException($"User with ID: {request.Id} could not be found");
            }

            return _mapper.Map<UserModel>(userEntity);
        }
    }
}
