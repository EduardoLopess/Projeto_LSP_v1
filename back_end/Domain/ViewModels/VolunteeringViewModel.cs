using Domain.Entities;
using Domain.Enums;

namespace Domain.ViewModels
{
    public class VolunteeringViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TypeVolunteering VolunteeringType { get; set; }
        public IList<BenefitViewModel> BenefitViewModels { get; set; }
        public IList<ResponsabilityViewModel> ResponsabilityViewModels { get; set; }
       

        public InstituteViewModel InstituteViewModel { get; set; }
        public int AssociatedInstitutionId { get; set; } 
    }
}