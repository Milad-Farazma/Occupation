using LearningManagement.Occupation.Application.Shared;
using LearningManagement.Occupation.WebAPI.Middlewares;
using LearningManagement.Occupation.WebAPI.Shared;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Occupation")
                       ?? throw new ArgumentException("Can not find database connection string.");
var allowedCorsOrigins = builder.Configuration.GetSection("AllowedCorsOrigins").Get<string[]>();
ServiceRegistrations.AddAllServices(builder.Services, connectionString, allowedCorsOrigins ?? []);

// Add services to the container.
builder.Services.AddControllers();

// Read configuration from appsettings.json
builder.Host.UseSerilog((context, configuration) =>
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSerilogRequestLogging();
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

ApplicationServiceRegistration.MapGrpcServices(app);

app.MapControllers();

app.Run();