using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IBenefitRepository : IBaseRepository<Benefit>
    {
        Task CreateAsync(Benefit entity, Volunteering volunteering);
    }
}