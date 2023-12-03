using Domain.Enums;

namespace Domain.Entities
{
    public class Institute : LoginInfos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string CNPJ { get; set;}
        

        public InstitutionType InstitutionType { get; set; }
        public Address Address { get; set; }
        public IList<Volunteering> Volunteerings { get; set; }
        public IList<DonationMaterial> DonationMaterials { get; set; }
 
    }
}