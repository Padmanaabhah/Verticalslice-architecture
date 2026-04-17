using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelInspiration.API.Shared.Domain.Entities;
using TravelInspiration.API.Shared.Persistence.Migrations;

namespace TravelInspiration.API.Features.Itineraries
{
    public static class SearchItineraries
    {
        public static void AddEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("api/itineraries",
                async (string? searchFor,
                       ILoggerFactory loggerFactory,
                       TravelInspirationDbContext dbContext,
                       IMapper mapper,
                       CancellationToken cancellationToken) =>
                {
                    loggerFactory.CreateLogger("EndpointHandlers").LogInformation("Search Itineraries");
                    //var resultFromApiCall = await itinerarySearchApiClient.GetItinerariesAsync(searchFor, cancellationToken);
                    //var result = resultFromApiCall.Select(itinerary => new
                    //{
                    //    itinerary.Name,
                    //    itinerary.Description,
                    //    itinerary.ImageUri
                    //});
                    //return Results.Ok(result);

                    var resultFromDb = await dbContext.Itenaries
                        .Where(itinerary => searchFor == null || itinerary.Name.Contains(searchFor) ||
                        (itinerary.Description !=null && itinerary.Description.Contains(searchFor))) 
                        .ToListAsync(cancellationToken);

                    return Results.Ok(mapper.Map<List<ItineraryDto>>(resultFromDb));


                });
        }
    }

    public sealed class ItineraryDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUri { get; set; }
    }

    public sealed class itineraryMapperProfile : Profile
    {
        public itineraryMapperProfile()
        {
            CreateMap<Itinerary, ItineraryDto>();
        }
    }
}
