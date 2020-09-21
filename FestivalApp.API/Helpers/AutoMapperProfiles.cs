using AutoMapper;
using FestivalApp.API.Dtos;
using FestivalApp.API.Models;

namespace FestivalApp.API.Helpers
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