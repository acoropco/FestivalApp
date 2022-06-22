using AutoMapper;
using FestivalApp.API.DTOs;
using FestivalApp.Core.Models;
using FestivalApp.Domain.Entities;

namespace FestivalApp.API.MappingProfiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // User models mappings
            CreateMap<UserForRegisterDto, User>();
            CreateMap<UserModel, UserForSiteDto>();
            CreateMap<UserEditDto, UserModel>();
            CreateMap<UserModel, UserProfileDto>();
            CreateMap<User, UserProfileDto>();
            CreateMap<UserProfileDto, User>();
            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();

            // Festival model mappings
            CreateMap<FestivalModel, FestivalForListDto>();
            CreateMap<FestivalForCreationDto, FestivalModel>();
            CreateMap<FestivalForListDto, FestivalModel>();
            
            // Rentals models mappings
            CreateMap<RentalForCreationDto, RentalModel>();
            CreateMap<RentalModel, RentalForListDto>();
            
        }
    }
}