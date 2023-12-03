using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDonationPointRepository : IBaseRepository<DonationPoint>
    {
        Task CreateAsync(DonationPoint entity, Address address, IList<DonationMaterial> donationMaterials);
        //Task CreateAsync(DonationPoint entity, Address address, Institute institute, IList<DonationMaterial> donationMaterials);

    }
}