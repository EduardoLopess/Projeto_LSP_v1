using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class DonationPointRepository : IDonationPointRepository
    {
        private readonly DataContext _context;

        public DonationPointRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(DonationPoint entity, Address address, IList<DonationMaterial> donationMaterials)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (donationMaterials == null || donationMaterials.Count == 0)
            {
                throw new ArgumentNullException(nameof(donationMaterials), "A lista de DonationMaterials não pode estar vazia.");
            }

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                // Adicione o DonationPoint
                _context.DonationPoints.Add(entity);

                // Associe o Address e o Institute ao DonationPoint
                entity.Address = address;
            

                // Associe os DonationMaterials ao DonationPoint
                foreach (var material in donationMaterials)
                {
                    entity.DonationMaterials.Add(material);
                }

                // Salve as alterações para DonationPoint (que inclui Address, Institute e DonationMaterials)
                await _context.SaveChangesAsync();

                // Conclua a transação
                transaction.Commit();
            }
            catch (Exception)
            {
                // Em caso de erro, reverta a transação
                transaction.Rollback();
                throw;

            }
        }


        public async Task DeleteAsync(int entityId)
        {
            var entity = await _context.DonationPoints.FindAsync(entityId);
            if (entity != null)
            {
                _context.DonationPoints.Remove(entity);
                await 
                    _context.SaveChangesAsync();
            }
        }

        public async Task<IList<DonationPoint>> GetAllAsync()
        {
            return 
                await 
                    _context.DonationPoints
                    .Include(a => a.Address)
                    .Include(i => i.Institute)
                    .Include(m => m.DonationMaterials)
                    .ToListAsync();
        }

        public async Task<DonationPoint> GetByIdAsync(int entityId)
        {
            return 
                await 
                    _context.DonationPoints
                    .Include(a => a.Address)
                    .Include(i => i.Institute)
                    .Include(m => m.DonationMaterials)
                    .SingleOrDefaultAsync(b => b.Id == entityId);
        }

        public async Task UpdateAsync(DonationPoint entity)
        {
            var existDonationPoint = await _context.DonationPoints
                                    .Include(a => a.Address)
                                    .Include(i => i.Institute)
                                    .Include(m => m.DonationMaterials)
                                    .FirstOrDefaultAsync(d => d.Id == entity.Id);
            if(existDonationPoint != null)
            {
                _context.Entry(existDonationPoint).CurrentValues.SetValues(entity);
                await
                    _context.SaveChangesAsync();
            }

        }
    }
}
