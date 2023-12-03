using Domain.Enums;

namespace Domain.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string CPF { get; set; }
        public string BirthdateString { get; set; }

        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public IList<AddressDTO> AddressesDTO { get; set; }
        public ProfileAcess ProfileAcess { get; set; }
    }
}