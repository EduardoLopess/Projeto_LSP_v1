using Domain.Entities;

namespace Domain.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string Neighborhood  { get; set; } //Bairro
        public string Complement { get; set; } 
        public int ZipCode { get; set; }
        public string City { get; set; }

        // public int UserId { get; set; }
        // public int InstituteId { get; set; }
        // public int DonationPointId { get; set; }
    }
}