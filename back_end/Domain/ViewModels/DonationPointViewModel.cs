using Domain.Entities;
using Domain.Enums;

namespace Domain.ViewModels
{
    public class DonationPointViewModel
    {
        public string Description { get; set; }
        public TypeMaterial TypeMaterial { get; set; }
        public AdressViewModel AdressViewModel { get; set; }
        public IList<DonationMaterial> DonationMaterials { get; set; }
    }
}