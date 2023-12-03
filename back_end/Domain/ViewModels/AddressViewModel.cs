namespace Domain.ViewModels
{
    public class AdressViewModel
    {
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string Neighborhood  { get; set; } //Bairro
        public string Complement { get; set; } 
        public int ZipCode { get; set; }
        public string City { get; set; }

         //public IList<UserViewModel> UserViewModels { get; set; }
        // public IList<InstituteViewModel> InstituteViewModels { get; set; }
        // public IList<DonationPointViewModel> DonationPointViewModels { get; set; }
    }
}