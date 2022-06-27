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
            CreateMap<FestivalModel, FestivalDetailsDto>();
            CreateMap<FestivalModel, Festival>();
            CreateMap<FestivalModel, FestivalDetailsDto>();
            CreateMap<Festival, FestivalModel>();
            CreateMap<FestivalRequestDto, FestivalModel>();
            CreateMap<FestivalDetailsDto, FestivalModel>();
            CreateMap<FestivalRequestDto, FestivalUpdateModel>();
            CreateMap<FestivalUpdateModel, Festival>();
            
            // Rentals models mappings
            CreateMap<RentalRequestDto, RentalModel>();
            CreateMap<RentalModel, RentalDetailsDto>();
            CreateMap<RentalModel, Rental>();
            CreateMap<Rental, RentalModel>();
            CreateMap<Rental, RentalDetailsDto>();
            CreateMap<RentalRequestDto, RentalUpdateModel>();
            CreateMap<RentalUpdateModel, Rental>();
        }
    }
}