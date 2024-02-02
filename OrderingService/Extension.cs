using Microsoft.EntityFrameworkCore;
using OrderingService.ORM.EF;

namespace OrderingService;

public static class ServiceExtension
{
    public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration config)
    {
        string? machineName = Environment.MachineName;
        string? ConnectionString = config["sqlConnection"];
        ConnectionString = ConnectionString!.Replace("??????", machineName);

        services.AddDbContext<OrderingContext>(opts =>
            opts.UseSqlServer(ConnectionString));
    }
}
