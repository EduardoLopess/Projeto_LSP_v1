namespace Domain.Entities
{
    public class Benefit
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Volunteering Volunteering { get; set; }
    }
}