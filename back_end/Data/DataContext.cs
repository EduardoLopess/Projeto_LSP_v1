using System.Runtime.CompilerServices;
using Domain.Entities;
using Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext() {}
        public string DbPath { get; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            string path = Directory.GetCurrentDirectory();
            DbPath = Path.Join(path, "bancoLocal.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source = {DbPath}");

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Responsibility> Responsibilities { get; set; }
        public DbSet<DonationMaterial> DonationMaterials { get; set; }
        public DbSet<DonationPoint> DonationPoints { get; set; }
        public DbSet<Volunteering> Volunteerings { get; set; }
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Login> Logins { get; set; }
       
    }
}