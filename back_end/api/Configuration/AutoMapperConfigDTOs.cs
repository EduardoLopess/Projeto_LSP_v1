using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Services;

namespace api.Configuration
{
    public class AutoMapperConfigDTOs : Profile
    {
        public AutoMapperConfigDTOs()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.FullName, map => map.MapFrom(src => $"{src.Name} {src.Surname}"))
                .ForMember(dest => dest.AddressesDTO, map => map.MapFrom(src => src.Addresses));
            
            CreateMap<Address, AddressDTO>();
             

            CreateMap<Volunteering, VolunteeringDTO>()
                .ForMember(dest => dest.BenefitDTOs, map => map.MapFrom(src => src.Benefits))
                .ForMember(dest => dest.ResposibilityDTOs, map => map.MapFrom(src => src.Responsibility))
                .ForMember(dest => dest.InstituteDTOs, map => map.MapFrom(src => src.Institute))
                .ForMember(dest => dest.TypeVolunteering, map => map.MapFrom(src => src.TypeVolunteering));

            CreateMap<Institute, InstituteDTO>()
                .ForMember(dest => dest.PhoneNumber, map => map.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.CNPJ, map => map.MapFrom(src => src.CNPJ))
                .ForMember(dest => dest.InstitutionType, map => map.MapFrom(src => src.InstitutionType))
                .ForMember(dest => dest.ProfileAcess, map => map.MapFrom(src => src.ProfileAcess))
                .ForMember(dest => dest.AddressDTO, map => map.MapFrom(src => src.Address))
                .ForMember(dest => dest.VolunteeringDTOs, map => map.MapFrom(src => src.Volunteerings))
                .ForMember(dest => dest.DonationMaterialDTOs, map => map.MapFrom(src => src.DonationMaterials));

            CreateMap<Benefit, BenefitDTO>()
                .ForMember(dest => dest.VolunteeringDTO, map => map.MapFrom(src => src.Volunteering));

            CreateMap<Responsibility, ResponsabilityDTO>();
            
               

            CreateMap<DonationMaterial, DonationMaterialDTO>();
            
            CreateMap<Login, LoginDTO>();
                

            CreateMap<DonationPoint, DonationPointDTO>()
                .ForMember(dest => dest.AddressDTO, map => map.MapFrom(src => src.Address))
                .ForMember(dest => dest.DonationMaterialDTOs, map => map.MapFrom(src => src.DonationMaterials));
         
        }
    }
}
