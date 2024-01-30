using ProductService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.ConfigureSqlServer(builder.Configuration);


var app = builder.Build();


// Configure the HTTP request pipeline.



app.Run();
