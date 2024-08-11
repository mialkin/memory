using Microsoft.OpenApi.Models;

namespace Memory.Api.Endpoints.Lohs.GenerateLargeStrings;

public static class GenerateLargeStringsEndpoint
{
    public static void GenerateLargeStrings(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapPost(routePattern, () =>
            {
                var array = new Class[10_000_000];
                for (var i = 0; i < 10_000_000; i++)
                {
                    array[i] = new Class { Id = i };
                }

                return Results.Ok();
            })
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Generate large strings" });
    }
}
