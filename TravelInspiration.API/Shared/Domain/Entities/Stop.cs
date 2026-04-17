namespace TravelInspiration.API.Shared.Domain.Entities
{
    public sealed class Stop(string name) : AuditableEntities
    {
        public int Id { get; set; }

        public string Name { get; set; } = name;

        public Uri? ImageUri { get; set; }

        public int ItenaryId { get; set; }

        public Itinerary? Itinerary { get; set; }
    }
}
