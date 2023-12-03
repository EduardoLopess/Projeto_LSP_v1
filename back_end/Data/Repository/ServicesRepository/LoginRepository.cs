using Domain.DTOs;
using Domain.Services.ServicesInterfaces;

namespace Data.Repository.ServicesRepository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DataContext _context;
        public LoginRepository(DataContext context)
        {
            _context = context;
        }

        
        public Task<InstituteDTO> InstituteLoginAsync(LoginDTO loginCredentials)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InstituteLogoutAsync(int instituteId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RecoverPasswordAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> UserLoginAsync(LoginDTO loginCredentials)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserLogoutAsync(int userId)
        {
            throw new NotImplementedException();
        }

    }
}