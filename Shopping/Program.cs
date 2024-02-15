using MasterDataService;
using Shopping.API;
using Shopping.API.Services;
using Shopping.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddGrpcClient<CustomerProto.CustomerProtoClient>(opts =>
{
    opts.Address = new Uri("https://localhost:7101");
});

builder.Services.AddTransient<IServiceManager, ServiceManager>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.ConfigureExceptionHandler();

app.MapControllers();

app.Run();
