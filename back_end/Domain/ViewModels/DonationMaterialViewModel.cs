using Domain.Enums;

namespace Domain.ViewModels
{
    public class DonationMaterialViewModel
    {
        public string Name { get; set; }
        public TypeMaterial TypeMaterial { get; set; }
        public PriorityDonation PriorityDonation { get; set;}
        public DonationPointViewModel DonationPointViewModel { get; set; }
        public InstituteViewModel InstituteViewModel { get; set; }

    }
}