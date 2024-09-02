using Microsoft.OpenApi.Models;

namespace Memory.Api.Endpoints.Lohs.GenerateLargeStrings;

public static class GenerateLargeStringsEndpoint
{
    public static void GenerateLargeStrings(this IEndpointRouteBuilder builder, string routePattern)
    {
        builder.MapPost(routePattern, () =>
            {
                new ClassWithFinalizer();
                Console.WriteLine("Start collecting garbage");
                GC.Collect();

                Console.WriteLine("Start waiting pending finalizers");
                GC.WaitForPendingFinalizers();
                Console.WriteLine("End waiting pending finalizers");

                return Results.Ok();
            })
            .WithOpenApi(x => new OpenApiOperation(x) { Summary = "Generate large strings" });
    }
}
