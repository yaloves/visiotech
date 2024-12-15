using Microsoft.EntityFrameworkCore;
using System;
using Visiotech_API.Models.Entities;

namespace Visiotech_API.Data
{
    public class PostgresDbContext(DbContextOptions<PostgresDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("vineyards");

            modelBuilder.Entity<ParcelEntity>()
                .HasOne(p => p.Manager)
                .WithMany(m => m.Parcels)
                .HasForeignKey(p => p.ManagerEntityId); 
            
            modelBuilder.Entity<ParcelEntity>()
                .HasOne(p => p.Grape)
                .WithMany(g => g.Parcels)
                .HasForeignKey(p => p.GrapeEntityId); 
            
            modelBuilder.Entity<ParcelEntity>()
                .HasOne(p => p.Vineyard)
                .WithMany(v => v.Parcels)
                .HasForeignKey(p => p.VineyardEntityId);
        }

        public virtual DbSet<ManagerEntity> Managers { get; set; } = null!;
        public virtual DbSet<GrapeEntity> Grapes { get; set; } = null!;
        public virtual DbSet<VineyardEntity> Vineyards { get; set; } = null!;
        public virtual DbSet<ParcelEntity> Parcels { get; set; } = null!;

    }
}
