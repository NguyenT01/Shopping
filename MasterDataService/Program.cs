using MasterDataService;
using MasterDataService.ORM.EF;
using MasterDataService.ORM.EF.Interface;
using MasterDataService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddAutoMapper(typeof(Program));

//Repository
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.ConfigureSqlServer(builder.Configuration);
builder.Services.ConfigureDapperConnection(builder.Configuration);

var app = builder.Build();

app.ConfigureExceptionHandler();

// Configure the HTTP request pipeline.
app.MapGrpcService<CustomerService>();

app.Run();
