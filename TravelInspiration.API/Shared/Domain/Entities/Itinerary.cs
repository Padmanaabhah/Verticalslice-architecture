using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TravelInspiration.API.Shared.Domain.Entities
{
    public sealed class Itinerary(string name, string userId) : AuditableEntities
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = name;

        public string? Description { get; set; }

        public string UserId { get; set; } = userId;

        public ICollection<Stop> Stops { get; set; } = [];
    }
}