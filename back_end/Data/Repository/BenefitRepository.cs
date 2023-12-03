using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class BenefitRepository : IBenefitRepository
    {
        public readonly DataContext _context;
        public BenefitRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Benefit entity, Volunteering volunteering)
        {
            if (volunteering == null)
            {
                throw new ArgumentNullException(nameof(volunteering), "Volunteering cannot be null.");
            }

            // Verifique se o objeto de voluntariado existe no banco de dados.
            var existingVolunteering = await _context.Volunteerings
                .SingleOrDefaultAsync(v => v.Id == volunteering.Id);

            entity.Volunteering = existingVolunteering ?? throw new ArgumentException($"Volunteering with Id {volunteering.Id} does not exist in the database.");
            
            _context.Add(entity);
            await 
                _context.SaveChangesAsync();
                
        }

        public async Task<IList<Benefit>> GetAllAsync()
        {
            return
                await _context.Benefits
                    .Include(v => v.Volunteering)
                    .ToListAsync();
        }

        public async Task<Benefit> GetByIdAsync(int entityId)
        {
           return
                await _context.Benefits
                    .Include(v => v.Volunteering)
                    .SingleOrDefaultAsync(b => b.Id == entityId);
        }

        public async Task UpdateAsync(Benefit entity)
        {
            var existBenefit = await _context.Benefits
                                .Include(v => v.Volunteering)
                                .FirstOrDefaultAsync(a => a.Id == entity.Id);
            if(existBenefit != null)
            {
                _context.Entry(existBenefit).CurrentValues.SetValues(entity);
                await
                    _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int entityId)
        {
            var existBenefit = await _context.Benefits
                                .Include(v => v.Volunteering)
                                .FirstOrDefaultAsync(a => a.Id == entityId);
            if(existBenefit != null)
            {
                _context.Benefits.Remove(existBenefit);
                await
                    _context.SaveChangesAsync();
            }
        }

    }
}