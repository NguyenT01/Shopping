using MasterDataService;
using Shopping.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddConsul("http://192.168.52.72:8500");
builder.Services.ConfigureGrpcClient();

builder.Services.ConfigureDIManager();

// MediatR Registration
builder.Services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.ConfigureExceptionHandler();

app.MapControllers();

app.Run();
