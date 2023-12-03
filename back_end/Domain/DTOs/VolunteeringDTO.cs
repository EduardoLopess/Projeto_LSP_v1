using Domain.Enums;

namespace Domain.DTOs
{
    public class VolunteeringDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Duration { get; set; }
        public IList<BenefitDTO> BenefitDTOs { get; set; }
        public IList<ResponsabilityDTO> ResposibilityDTOs { get; set; }
        public IList<UserDTO> UsersParticipantsDTO { get; set; }
        public TypeVolunteering TypeVolunteering { get; set; } 

        public InstituteDTO InstituteDTOs { get; set; }
    }
}