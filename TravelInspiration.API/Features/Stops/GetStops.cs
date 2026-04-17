using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelInspiration.API.Shared.Domain.Entities;
using TravelInspiration.API.Shared.Persistence.Migrations;

namespace TravelInspiration.API.Features.Stops
{
    public static class GetStops
    {
        public static void AddEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("api/stops",
                async (int itineraryId,
                       ILoggerFactory loggerFactory,
                       TravelInspirationDbContext dbContext,
                       IMapper mapper,
                       CancellationToken cancellationToken) =>
                {
                    loggerFactory.CreateLogger("GetStops").LogInformation("Getting stops for itinerary {ItineraryId}", itineraryId);

                    var itinerary = await dbContext.Itenaries
                        .Include(i => i.Stops)
                        .FirstOrDefaultAsync(i => i.Id == itineraryId, cancellationToken);

                    if (itinerary == null)
                    {
                        return Results.NotFound();
                    }

                    return Results.Ok(mapper.Map<IEnumerable<StopDto>>(itinerary.Stops));
                });
        }
    }

    public sealed class StopDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? ImageUri { get; set; }

        public required int ItineraryId{ get; set; }
    }

    public sealed class StopMapperProfile : Profile
    {
        public StopMapperProfile()
        {
            CreateMap<Stop, StopDto>();
        }
    }
}
