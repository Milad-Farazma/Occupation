using LMS.Aquamation.WebAPI;
using LMS.Aquamation.WebAPI.GrpcServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddGrpc();

var connectionString = builder.Configuration.GetConnectionString("Default")
                       ?? throw new ArgumentException("Can not find database connection string.");
ServiceRegistrations.AddServices(builder.Services, connectionString);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGrpcService<MyGrpcService>();
app.MapControllers();

app.Run();