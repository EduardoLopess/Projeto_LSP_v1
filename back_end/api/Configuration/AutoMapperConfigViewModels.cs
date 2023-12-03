using AutoMapper;
using Domain.Entities;
using Domain.Services;
using Domain.ViewModels;
using Domain.ViewModels.ServicesViewModels;

namespace api.Configuration
{
    public class AutoMapperConfigViewModels : Profile
    {
        public AutoMapperConfigViewModels()
        {
            CreateMap<UserViewModel, User>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.BirthdateString, opt => opt.MapFrom(src => src.BirthdateString))                
                .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.CPF))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.AdressViewModels));

            CreateMap<AdressViewModel, Address>();
             
            CreateMap<BenefitViewModel, Benefit>();

            CreateMap<ResponsabilityViewModel, Responsibility>();

            CreateMap<InstituteViewModel, Institute>();

            CreateMap<VolunteeringViewModel, Volunteering>();
            
            CreateMap<LoginViewModel, Login>();

            CreateMap<DonationMaterialViewModel, DonationMaterial>();

            CreateMap<DonationPointViewModel, DonationPoint>();
        }
    }
}