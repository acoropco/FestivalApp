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
            CreateMap<UserEditDto, UserUpdateModel>();
            CreateMap<UserUpdateModel, User>();
            CreateMap<UserModel, UserProfileDto>();
            CreateMap<User, UserProfileDto>();
            CreateMap<UserProfileDto, User>();
            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();

            // Festival model mappings
            CreateMap<FestivalModel, FestivalDto>();
            CreateMap<FestivalModel, Festival>();
            CreateMap<FestivalModel, FestivalDto>();
            CreateMap<Festival, FestivalModel>();
            CreateMap<FestivalForCreationDto, FestivalModel>();
            CreateMap<FestivalDto, FestivalModel>();
            
            // Rentals models mappings
            CreateMap<RentalForCreationDto, RentalModel>();
            CreateMap<RentalModel, RentalDto>();
            CreateMap<RentalModel, Rental>();
            CreateMap<Rental, RentalModel>();
            
        }
    }
}