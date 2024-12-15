using System;
using Visiotech_API.Data;
using Visiotech_API.Models.Entities;

namespace Visiotech_API.Extensions
{
    public static class DbContextExtensions
    {
        public static void SeedDatabase(this PostgresDbContext context)
        {
            context.Database.EnsureCreated();

            ManagerEntity[] managers = [];
            if (!context.Managers.Any())
            {
                managers =
                [
                new ManagerEntity { Id = Guid.NewGuid(), TaxNumber = "132254524", Name = "Miguel Torres" },
                new ManagerEntity { Id = Guid.NewGuid(), TaxNumber = "143618668", Name = "Ana Martín" },
                new ManagerEntity { Id = Guid.NewGuid(), TaxNumber = "78903228", Name = "Carlos Ruiz" }
                ];
                context.Managers.AddRange(managers);
            }

            GrapeEntity[] grapes = [];
            if (!context.Grapes.Any())
            {
                grapes =
                [
                new GrapeEntity { Id = Guid.NewGuid(), Name = "Tempranillo" },
                new GrapeEntity { Id = Guid.NewGuid(), Name = "Albariño" },
                new GrapeEntity { Id = Guid.NewGuid(), Name = "Garnacha" }
                ];
                context.Grapes.AddRange(grapes);
            }
            
            VineyardEntity[] vineyards = [];
            if (!context.Vineyards.Any())
            {
                vineyards =
                [
                new VineyardEntity { Id = Guid.NewGuid(), Name = "Viña Esmeralda" },
                new VineyardEntity { Id = Guid.NewGuid(), Name = "Bodegas Bilbaínas" }
                ];
                context.Vineyards.AddRange(vineyards);
            }

            ParcelEntity[] parcels = [];
            if (!context.Parcels.Any())
            {
                parcels =
                [
                new ParcelEntity { Id = Guid.NewGuid(), ManagerEntityId = managers[0].Id, GrapeEntityId = grapes[0].Id, VineyardEntityId = vineyards[0].Id, YearPlanted = 2019, Area = 1500 },
                new ParcelEntity { Id = Guid.NewGuid(), ManagerEntityId = managers[1].Id, GrapeEntityId = grapes[1].Id, VineyardEntityId = vineyards[1].Id, YearPlanted = 2021, Area = 9000 },
                new ParcelEntity { Id = Guid.NewGuid(), ManagerEntityId = managers[2].Id, GrapeEntityId = grapes[0].Id, VineyardEntityId = vineyards[1].Id, YearPlanted = 2020, Area = 3000 },
                new ParcelEntity { Id = Guid.NewGuid(), ManagerEntityId = managers[0].Id, GrapeEntityId = grapes[1].Id, VineyardEntityId = vineyards[0].Id, YearPlanted = 2020, Area = 2000 },
                new ParcelEntity { Id = Guid.NewGuid(), ManagerEntityId = managers[2].Id, GrapeEntityId = grapes[1].Id, VineyardEntityId = vineyards[1].Id, YearPlanted = 2021, Area = 1000 }
                ];
                context.Parcels.AddRange(parcels);
            }

            context.SaveChanges();
        }
    }
}
