using TravelInspiration.API.Shared.Networking;

namespace TravelInspiration.API.Features.Destinations
{
    public static class SearchDestinations
    {
        public static void AddEndpoint(IEndpointRouteBuilder app, CancellationToken cancellationToken)
        {
            app.MapGet("api/destinations",
                async (string? searchFor,
                       ILoggerFactory loggerFactory,
                       CancellationToken cancellationToken,
                       IDestinationSearchApiClient destinationSearchApiClient) =>
                {
                    loggerFactory.CreateLogger("EndpointHandlers").LogInformation("Search Destinations");

                    var resultFromApiCall = await destinationSearchApiClient.GetDestinationsAsync(searchFor, cancellationToken);

                    var result = resultFromApiCall.Select(destination => new 
                    {
                        destination.Name,
                        destination.Description,     
                        destination.ImageUri
                    });

                    return Results.Ok(result);
                });
        }
    }
}
