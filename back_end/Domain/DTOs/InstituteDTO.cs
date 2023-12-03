using Domain.Enums;

namespace Domain.DTOs
{
    public class InstituteDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string CNPJ { get; set; }
        public InstitutionType InstitutionType { get; set; }
        public AddressDTO AddressDTO { get; set; }
        public ProfileAcess ProfileAcess { get; set; }
        public LoginDTO LoginDTO { get; set; }
        public IList<VolunteeringDTO> VolunteeringDTOs { get; set; }
        public IList<DonationMaterialDTO> DonationMaterialDTOs { get; set; }
    }
}