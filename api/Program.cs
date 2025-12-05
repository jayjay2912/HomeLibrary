using Gemstone.HomeLibrary.Mapper;
using Gemstone.HomeLibrary.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights()
    .AddMemoryCache()
    .AddAutoMapper(typeof(MappingProfile))
    .AddScoped<IBookService, BookService>();

builder.Build().Run();
