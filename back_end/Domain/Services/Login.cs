using Domain.Entities;
using Domain.Enums;

namespace Domain.Services
{
    public class Login
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ProfileAcess ProfileAcess { get; set; }

    }
}