using Domain.Enums;

namespace Domain.Entities
{
    public class DonationMaterial
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PriorityDonation PriorityDonation { get; set; }
        public TypeMaterial TypeMaterial { get; set; }
        public DonationPoint DonationPoint { get; set; }
        public Institute Institute { get; set; }
    }
}