namespace Domain.DTOs
{
    public class ResponsabilityDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public VolunteeringDTO VolunteeringDTOs { get; set; }
    }
}