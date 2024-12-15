using Microsoft.EntityFrameworkCore;
using System;
using Visiotech_API.Models.Entities;

namespace Visiotech_API.Data
{
    public class PostgresDbContext(DbContextOptions<PostgresDbContext> options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=postgres_db;Database=db;Username=user;Password=Bz3kW.AJT7MV8t@");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("vineyard");
        }

        public virtual DbSet<ManagerEntity> Managers { get; set; } = null!;
        public virtual DbSet<GrapeEntity> Grapes { get; set; } = null!;
        public virtual DbSet<VineyardEntity> Vineyards { get; set; } = null!;
        public virtual DbSet<ParcelEntity> Parcels { get; set; } = null!;

    }
}
