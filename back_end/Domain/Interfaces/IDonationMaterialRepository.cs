using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDonationMaterialRepository : IBaseRepository<DonationMaterial>
    {
        Task CreateAsync(DonationMaterial entity, DonationPoint donationPoint);
    }
}