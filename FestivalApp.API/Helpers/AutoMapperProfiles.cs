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
        }
    }
}