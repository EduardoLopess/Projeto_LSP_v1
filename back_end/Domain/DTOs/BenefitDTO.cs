namespace Domain.DTOs
{
    public class BenefitDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public VolunteeringDTO VolunteeringDTO { get; set; }
    }
}