namespace Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string Neighborhood  { get; set; } //Bairro
        public string Complement { get; set; } 
        public int ZipCode { get; set; }
        public string City { get; set; }

        public IList<User> Users { get; set; }
        public int UserId { get; set;}
        public IList<DonationPoint> DonationPoints { get; set; }
        public int DonationPointId { get; set;}
        public IList<Institute> Institutes { get; set; }
        public int InstituteId { get; set; }
    }
}