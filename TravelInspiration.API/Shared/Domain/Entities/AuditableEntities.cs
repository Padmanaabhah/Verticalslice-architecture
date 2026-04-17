namespace TravelInspiration.API.Shared.Domain.Entities
{
    public abstract class AuditableEntities
    {
        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

        public DateTime LastUpdatedOn { get; set; }

        public string? LastModifiedBy { get; set; }

    }
}
