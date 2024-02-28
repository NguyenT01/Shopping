using ProductServiceNamespace;
using ProductServiceNamespace.ORM.EF;
using ProductServiceNamespace.ORM.EF.Interface;
using ProductServiceNamespace.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
await builder.Services.ConfigureConsulClient();
builder.Services.AddGrpc();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.ConfigureSqlServer(builder.Configuration);


var app = builder.Build();


// Configure the HTTP request pipeline.

app.MapGrpcService<ProductService>();
app.MapGrpcService<PriceService>();

app.Run();
