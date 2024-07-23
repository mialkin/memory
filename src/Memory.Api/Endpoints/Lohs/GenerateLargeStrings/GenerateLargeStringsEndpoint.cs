using System.Security.Cryptography;
using Microsoft.OpenApi.Models;

namespace Memory.Api.Endpoints.Lohs.GenerateLargeStrings;

public static class GenerateLargeStringsEndpoint
{
    public static void GenerateLargeStrings(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapPost(routePattern, (ILoggerFactory loggerFactory) =>
            {
                var logger = loggerFactory.CreateLogger(nameof(GenerateLargeStringsEndpoint));
                logger.LogInformation(
                    $"TotalAvailableMemoryBytes: {GC.GetGCMemoryInfo().TotalAvailableMemoryBytes}");

                var list = new List<string>();
                var counter = 1;

                while (true)
                {
                    var randomString = RandomNumberGenerator.GetString(
                        choices: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789",
                        length: 10_000_000);

                    list.Add(randomString);
                    logger.LogInformation("Added string " + counter);

                    counter++;

                    Thread.Sleep(500);

                    if (counter > 10)
                    {
                        break;
                    }
                }

                logger.LogInformation("Broke the loop");

                return Results.Ok();
            })
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Generate large strings" });
    }
}
