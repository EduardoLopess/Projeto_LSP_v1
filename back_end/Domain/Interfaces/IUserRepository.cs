using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task CreateAsync(User entity, Address address);

        Task SubscribeVolunteering(User entity, Volunteering volunteering);


        Task<bool> IsEmailAlreadyRegisteredAsync(string email); // valida Email
    }
}