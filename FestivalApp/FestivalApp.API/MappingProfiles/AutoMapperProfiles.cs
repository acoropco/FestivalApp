using AutoMapper;
using FestivalApp.API.DTOs;
using FestivalApp.Core.Models;

namespace FestivalApp.API.MappingProfiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserForRegisterDto, UserModel>();
            CreateMap<UserModel, UserForSiteDto>();
            CreateMap<FestivalModel, FestivalForListDto>();
            CreateMap<FestivalForCreationDto, FestivalModel>();
            CreateMap<FestivalForListDto, FestivalModel>();
            CreateMap<UserModel, UserProfileDto>();
            CreateMap<UserProfileDto, UserModel>();
            CreateMap<RentalForCreationDto, RentalModel>();
            CreateMap<RentalModel, RentalForListDto>();
            CreateMap<UserEditDto, UserModel>();
        }
    }
}