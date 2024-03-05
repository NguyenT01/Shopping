using MasterDataService;
using Shopping.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddRouting();
builder.Services.AddConsul();
builder.Services.AddHttpContextAccessor();

builder.Services.AddGrpc();
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


app.UseRouting();
//app.UseHttpsRedirection();

app.UseAuthorization();

app.ConfigureExceptionHandler();

app.MapControllers();

app.Run();
