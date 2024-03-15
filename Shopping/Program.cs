using AspNetCoreRateLimit;
using MasterDataService;
using Shopping.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.ConfigureGrpcClient(builder.Configuration);
builder.Services.ConfigureDIManager();

builder.Services.ConfigureFluentValidation();
builder.Services.ConfigureRateLimiting(builder.Configuration);

// MediatR Registration
builder.Services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

// Create RateLimit Middleware
app.UseIpRateLimiting();

app.UseAuthorization();

app.ConfigureExceptionHandler();

app.MapControllers();

app.Run();
