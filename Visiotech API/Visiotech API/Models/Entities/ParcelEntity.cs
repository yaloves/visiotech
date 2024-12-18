﻿namespace Visiotech_API.Models.Entities
{
    public class ParcelEntity
    {
        public Guid Id { get; set; }
        public int YearPlanted { get; set; }
        public double Area { get; set; }

        public Guid ManagerEntityId { get; set; }
        public Guid VineyardEntityId { get; set; }
        public Guid GrapeEntityId { get; set; }
        public ManagerEntity Manager { get; set; } = null!;
        public GrapeEntity Grape { get; set; } = null!;
        public VineyardEntity Vineyard { get; set; } = null!;
    }
}
