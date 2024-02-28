using OrderingService;
using OrderingService.ORM.EF;
using OrderingService.ORM.EF.Interface;
using OrderingService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
await builder.Services.ConfigureConsulClient();
builder.Services.AddGrpc();
builder.Services.ConfigureSqlServer(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IOrderingRepositoryManager, OrderingRepositoryManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<OrderService>();
app.MapGrpcService<OrderItemService>();

app.Run();
