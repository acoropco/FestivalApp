using AutoMapper;
using FestivalApp.API.DTOs;
using FestivalApp.Core.Models;

namespace FestivalApp.API.MappingProfiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserForRegisterDto, User>();
            CreateMap<User, UserForSiteDto>();
            CreateMap<Festival, FestivalForListDto>();
            CreateMap<FestivalForCreationDto, Festival>();
            CreateMap<FestivalForListDto, Festival>();
            CreateMap<User, UserProfileDto>();
            CreateMap<UserProfileDto, User>();
            CreateMap<RentalForCreationDto, Rental>();
            CreateMap<Rental, RentalForListDto>();
            CreateMap<UserEditDto, User>();
        }
    }
}