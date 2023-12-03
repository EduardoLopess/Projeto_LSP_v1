using System.Globalization;
using System.Text.Json.Serialization;
using Domain.Enums;

namespace Domain.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthdateString { get; set; }
        [JsonIgnore]
        public DateTime Birthdate
        {
            get
            {
                if (DateTime.TryParseExact(BirthdateString, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                {
                    return parsedDate;
                }
                return DateTime.MinValue; 
            }
            set
            {
                BirthdateString = value.ToString("dd-MM-yyyy");
            }
        }
        public Gender Gender { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        
        public ProfileAcess ProfileAcess { get; set; }
        public IList<AdressViewModel> AdressViewModels { get; set; }


    }
}