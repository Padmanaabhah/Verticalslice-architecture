using Microsoft.EntityFrameworkCore;
using TravelInspiration.API.Shared.Domain.Entities;

namespace TravelInspiration.API.Shared.Persistence.Migrations
{
    public sealed class TravelInspirationDbContext(
        DbContextOptions<TravelInspirationDbContext> options) : DbContext(options)
    {
        public DbSet<Itinerary> Itenaries => Set<Itinerary>();

        public DbSet<Stop> Stops => Set<Stop>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TravelInspirationDbContext).Assembly);

            modelBuilder.Entity<Itinerary>().HasData(
                new
                {
                    Id = 1,
                    Name = "A Trip to Paris",
                    Description = "Five days in the City of Light",
                    UserId = "user1",
                    CreatedOn = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedBy = "Paddy",
                    LastUpdatedOn = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new
                {
                    Id = 2,
                    Name = "Exploring Tokyo",
                    Description = "A week-long journey through Tokyo",
                    UserId = "user2",
                    CreatedOn = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedBy = "Paddy",
                    LastUpdatedOn = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                });

            modelBuilder.Entity<Stop>().HasData(
                new
                {
                    Id = 1,
                    Name = "Eiffel Tower",
                    ImageUri = new Uri("https://localhost/images/eiffel.jpg"),
                    ItenaryId = 1,
                    CreatedOn = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedBy = "Paddy",
                    LastUpdatedOn = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new
                {
                    Id = 2,
                    Name = "Louvre Museum",
                    ImageUri = new Uri("https://localhost/images/louvre.jpg"),
                    ItenaryId = 1,
                    CreatedOn = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedBy = "Paddy",
                    LastUpdatedOn = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new
                {
                    Id = 3,
                    Name = "Shibuya Crossing",
                    ImageUri = new Uri("https://localhost/images/shibuya.jpg"),
                    ItenaryId = 2,
                    CreatedOn = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedBy = "Paddy",
                    LastUpdatedOn = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new
                {
                    Id = 4,
                    Name = "Senso-ji Temple",
                    ImageUri = new Uri("https://localhost/images/sensoji.jpg"),
                    ItenaryId = 2,
                    CreatedOn = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    CreatedBy = "Paddy",
                    LastUpdatedOn = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                });

            base.OnModelCreating(modelBuilder); 
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntities>())
            {
                switch (entry.State)
                {    
                    case EntityState.Modified:
                        entry.Entity.LastUpdatedOn = DateTime.UtcNow;
                        entry.Entity.LastModifiedBy = "Paddy";
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.UtcNow;
                        entry.Entity.CreatedBy = "Paddy";
                        entry.Entity.LastUpdatedOn = DateTime.UtcNow;
                        entry.Entity.LastModifiedBy = "Paddy";
                        break;
                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
