using Memory.Api.Endpoints;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
    configuration.WriteTo.Console();
});

var services = builder.Services;

services.AddControllers();
services.AddRouting(options => options.LowercaseUrls = true);

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(options =>
{
    options.DescribeAllParametersInCamelCase();
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Memory API", Version = "v1" });
});

var application = builder.Build();

application.UseRouting();
application.UseSerilogRequestLogging();

application.UseSwagger();
application.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "v1");
    options.RoutePrefix = string.Empty;
    options.DocumentTitle = "Memory API";
});

application.MapEndpoints();

application.Run();
