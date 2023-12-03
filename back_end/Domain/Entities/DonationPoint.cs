using Domain.Enums;

namespace Domain.Entities
{
    public class DonationPoint
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public TypeMaterial TypeMaterial { get; set; }
        public Address Address { get; set; }
        public Institute Institute { get; set; }
        public IList<DonationMaterial> DonationMaterials { get; set; }
    }
}