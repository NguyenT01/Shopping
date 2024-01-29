using Microsoft.EntityFrameworkCore;
using ProductService.ORM.EF;

namespace ProductService;

public static class ServiceExtension
{
    public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration config)
    {
        string? machineName = Environment.MachineName;
        string? ConnectionString = config["sqlConnection"];
        ConnectionString = ConnectionString!.Replace("??????", machineName);

        services.AddDbContext<ProductRepositoryContext>(opts =>
            opts.UseSqlServer(ConnectionString));
    }
}
