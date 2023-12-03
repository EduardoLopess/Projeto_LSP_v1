using Domain.Enums;

namespace Domain.DTOs
{
    public class DonationPointDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        // public TypeMaterial TypeMaterial { get; set; }
        public AddressDTO AddressDTO { get; set; }
        //public InstituteDTO InstituteDTO { get; set; }
        public IList<DonationMaterialDTO> DonationMaterialDTOs { get; set; }
    }
}