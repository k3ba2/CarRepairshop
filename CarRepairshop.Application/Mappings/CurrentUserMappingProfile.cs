using AutoMapper;
using CarRepairshop.Application.CarRepairshop;
using CarRepairshop.Application.UserProfile;
using CarRepairshop.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CarRepairshop.Application.Mappings
{
    public class CurrentUserMappingProfile : Profile
    {
        public CurrentUserMappingProfile()
        {
            CreateMap<IdentityUser, CurrentUserDto>();
        }
    }
}
