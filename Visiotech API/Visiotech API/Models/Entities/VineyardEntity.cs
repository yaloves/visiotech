namespace Visiotech_API.Models.Entities
{
    public class VineyardEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ParcelEntity> Parcels { get; set; } = null!;

    }
}
