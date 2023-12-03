using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IInstituteRepository : IBaseRepository<Institute>
    {
        Task CreateAsync(Institute entity, Address address);
        Task CreateVolunteeringAsync(Institute institute, Volunteering volunteering);
    }
}