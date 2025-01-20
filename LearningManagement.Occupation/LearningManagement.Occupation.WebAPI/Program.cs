using LearningManagement.Occupation.Application.Shared.Extensions;
using LearningManagement.Occupation.Infrastructure.Shared.Extensions;
using LearningManagement.Occupation.WebAPI.Middlewares;
using LearningManagement.Occupation.WebAPI.Shared.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPresentation(builder.Configuration);

builder.Services.AddControllers();

// Read configuration from appsettings.json
builder.Host.UseSerilog((context, configuration) =>
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console()
);

var app = builder.Build();

app.UseSerilogRequestLogging();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.AllowSpecificOrigins();

app.MapControllers();

app.Run();