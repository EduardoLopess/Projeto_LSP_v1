using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class VolunteeringRepository : IVolunteeringRepository
    {
        private readonly DataContext _context;
        public VolunteeringRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Volunteering entity, IList<Responsibility> responsibilities, IList<Benefit> benefits)
        {
            entity.Responsibility = responsibilities;
            entity.Benefits = benefits;

            _context.Add(entity);

            // Adicione as responsabilidades e benefícios individualmente ao contexto
            foreach (var responsibility in responsibilities)
            {
                _context.Add(responsibility);
            }

            foreach (var benefit in benefits)
            {
                _context.Add(benefit);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IList<Volunteering>> GetAllAsync()
        {
            return
                await _context.Volunteerings
                    .Include(b => b.Benefits)
                    .Include(r => r.Responsibility)
                    .ToListAsync();
        }

        public async Task<Volunteering> GetByIdAsync(int entityId)
        {
            return
                await _context.Volunteerings
                    .Include(b => b.Benefits)
                    .Include(r => r.Responsibility)
                    .SingleOrDefaultAsync(v => v.Id == entityId);
        }

        public async Task UpdateAsync(Volunteering entity)
        {
            var existeVolunteering = await _context.Volunteerings
                                    .Include(b => b.Benefits)
                                    .Include(r => r.Responsibility)
                                    .FirstOrDefaultAsync(a => a.Id == entity.Id);
            if(existeVolunteering != null)
            {
                _context.Entry(existeVolunteering).CurrentValues.SetValues(entity);
                await
                    _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int entityId)
        {
            var existeVolunteering = await _context.Volunteerings
                                    .Include(b => b.Benefits)
                                    .Include(r => r.Responsibility)
                                    .FirstOrDefaultAsync(a => a.Id == entityId);

            if(existeVolunteering != null)
            {
                _context.Volunteerings.Remove(existeVolunteering);
                await
                    _context.SaveChangesAsync();
            }                         
        }

        public Task SubscribeVolunteering(Volunteering entity, User users)
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetUsersForVolunteeringAsync(Volunteering volunteering)
        {
            throw new NotImplementedException();
        }

    }
}