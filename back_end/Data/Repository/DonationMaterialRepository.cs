using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class DonationMaterialRepository : IDonationMaterialRepository
    {
        public readonly DataContext _context;
        public DonationMaterialRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(DonationMaterial entity, DonationPoint donationPoint)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await
                _context.DonationMaterials.AddAsync(entity);
        }
        public async Task<IList<DonationMaterial>> GetAllAsync()
        {
            return
                await
                    _context.DonationMaterials
                    .Include(t => t.TypeMaterial)//enum
                    .Include(d => d.DonationPoint)
                    .Include(i => i.Institute)
                    .ToListAsync();
        }

        public async Task<DonationMaterial> GetByIdAsync(int entityId)
        {
             return
                await
                    _context.DonationMaterials
                    .Include(t => t.TypeMaterial)//enum
                    .Include(d => d.DonationPoint)
                    .Include(i => i.Institute)
                    .SingleOrDefaultAsync(b => b.Id == entityId);
        }

        public async Task UpdateAsync(DonationMaterial entity)
        {
            var existDonationMaterials = await _context.DonationMaterials
                                        .Include(t => t.TypeMaterial)//enum
                                        .Include(d => d.DonationPoint)
                                        .Include(i => i.Institute)
                                        .FirstOrDefaultAsync(d => d.Id == entity.Id);
            if(existDonationMaterials != null)
            {
                _context.Entry(existDonationMaterials).CurrentValues.SetValues(entity);
                await
                    _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int entityId)
        {
            var entity = await _context.DonationMaterials.FindAsync(entityId);
            if (entity != null)
            {
                _context.DonationMaterials.Remove(entity);
                await 
                    _context.SaveChangesAsync();
            }
        }

    }
}