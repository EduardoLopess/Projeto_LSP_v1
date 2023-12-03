using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IResponsabilityRepository : IBaseRepository<Responsibility>
    {
        Task CreateAsync(Responsibility entity, Volunteering volunteering);
    }
}