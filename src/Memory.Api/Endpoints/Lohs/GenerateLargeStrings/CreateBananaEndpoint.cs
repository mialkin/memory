using System.Security.Cryptography;
using Microsoft.OpenApi.Models;

namespace Memory.Api.Endpoints.Lohs.GenerateLargeStrings;

public static class CreateBananaEndpoint
{
    public static void GenerateLargeStrings(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapPost(routePattern, () =>
            {
                var list = new List<string>();
                var counter = 1;

                while (true)
                {
                    var randomString = RandomNumberGenerator.GetString(
                        choices: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789",
                        length: 10_000_000);

                    list.Add(randomString);

                    Console.WriteLine(DateTime.Now);
                    Console.WriteLine($"TotalCommittedBytes: {GC.GetGCMemoryInfo().TotalCommittedBytes}");
                    Console.WriteLine($"TotalAvailableMemoryBytes: {GC.GetGCMemoryInfo().TotalAvailableMemoryBytes}");
                    counter++;

                    Thread.Sleep(500);

                    if (counter > 10)
                    {
                        break;
                    }
                }

                Console.WriteLine("Broke the loop");

                return Results.Ok();
            })
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Generate large strings" });
    }
}
