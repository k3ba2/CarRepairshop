using AutoMapper;
using CarRepairshop.Application.CarRepairshop;
using CarRepairshop.Domain.Entities;

namespace CarRepairshop.Application.Mappings
{
    public class CarRepairshopMappingProfile : Profile
    {
        public CarRepairshopMappingProfile()
        {
            CreateMap<Domain.Entities.CarRepairshop, CarRepairshopDto>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode))
                .ForMember(dest => dest.EncodedName, opt => opt.MapFrom(src => src.EncodedName))
                .ForMember(dest => dest.OpeningHours, opt => opt.MapFrom(src => src.CarRepairshopOpeningHours));

            CreateMap<CarRepairshopDto, Domain.Entities.CarRepairshop>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name ?? string.Empty))
                .ForMember(dest => dest.ContactDetails, opt => opt.MapFrom(src => new CarRepairshopContactDetails()
                {
                    PhoneNumber = src.PhoneNumber,
                    Street = src.Street,
                    City = src.City,
                    PostalCode = src.PostalCode
                }));

            CreateMap<Domain.Entities.CarRepairshop, ArchivedCarRepairshop>()
               .ForMember(dest => dest.CarRepairshopId, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.DeleteDate, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<CarRepairshopOpeningHour, CarRepairshopOpeningHourDto>();

            CreateMap<Appointment, AppointmentDto>();

            CreateMap<Service, ServiceDto>();

            CreateMap<Customer, CustomerDto>();
        }
    }
}
