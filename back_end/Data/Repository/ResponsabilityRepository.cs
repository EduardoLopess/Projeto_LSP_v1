using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class ResponsabilityRepository : IResponsabilityRepository
    {
        public readonly DataContext _context;
        public ResponsabilityRepository(DataContext context)
        {
            _context = context;
        }


        public async Task CreateAsync(Responsibility entity, Volunteering volunteering)
        {
            if(volunteering == null)
            {
                throw new ArgumentNullException(nameof(volunteering), "Volunteering cannot be null.");
            }

            var existResponsability = await _context.Volunteerings
                .SingleOrDefaultAsync(v => v.Id == volunteering.Id);

            if(existResponsability == null)
            {
                throw new ArgumentException($"Volunteering with Id {volunteering.Id} does not exist in the database.");
            } 
            entity.Volunteering = existResponsability;

            _context.Add(entity);
            await
                _context.SaveChangesAsync();   
        }

        public async Task<IList<Responsibility>> GetAllAsync()
        {
            return
                await _context.Responsibilities
                    .Include(v => v.Volunteering)
                    .ToListAsync();
        }

        public async Task<Responsibility> GetByIdAsync(int entityId)
        {
            return
                await _context.Responsibilities
                    .Include(v => v.Volunteering)
                    .SingleOrDefaultAsync(r => r.Id == entityId);
        }

        public async Task UpdateAsync(Responsibility entity)
        {
            var existResponsability = await _context.Responsibilities
                                        .Include(v => v.Volunteering)
                                        .FirstOrDefaultAsync(r => r.Id == entity.Id);
            if(existResponsability != null)
            {
                _context.Entry(existResponsability).CurrentValues.SetValues(entity);
                await
                    _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int entityId)
        {
            var existResponsability = await _context.Responsibilities
                                        .Include(v => v.Volunteering)
                                        .FirstOrDefaultAsync(r => r.Id == entityId);
            if(existResponsability != null)
            {
                _context.Responsibilities.Remove(existResponsability);
                await
                    _context.SaveChangesAsync();
            }
        }


    }
}