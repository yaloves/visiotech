namespace Visiotech_API.Models.Entities
{
    public class ManagerEntity
    {
        public Guid Id { get; set; }
        public string TaxNumber { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<ParcelEntity> Parcels { get; set; } = null!;
    }
}
