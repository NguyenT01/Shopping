using Microsoft.EntityFrameworkCore;
using ProductServiceNamespace.ORM.EF;

namespace ProductServiceNamespace;

public static class ServiceExtension
{
    public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration config)
    {
        string? machineName = Environment.MachineName;
        string? ConnectionString = config["sqlConnection"];
        ConnectionString = ConnectionString!.Replace("??????", machineName);

        services.AddDbContext<ProductContext>(opts =>
            opts.UseSqlServer(ConnectionString));
    }
}
