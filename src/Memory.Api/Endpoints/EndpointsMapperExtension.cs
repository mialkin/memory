using Memory.Api.Endpoints.Lohs.GenerateLargeStrings;

namespace Memory.Api.Endpoints;

public static class EndpointsMapperExtension
{
    public static void MapEndpoints(this IEndpointRouteBuilder builder)
    {
        MapBananaEndpoints(builder);
    }

    private static void MapBananaEndpoints(IEndpointRouteBuilder builder)
    {
        var groupBuilder = builder.MapGroup("api/generate-large-strings")
            .WithTags("Lohs");

        groupBuilder.GenerateLargeStrings("/");
    }
}
