using MasterDataService.ORM.EF;
using Microsoft.EntityFrameworkCore;

namespace MasterDataService;

public static class ServiceExtension
{
    public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration config)
    {
        string? machineName = Environment.MachineName;
        string? ConnectionString = config["sqlConnection"];
        ConnectionString = ConnectionString!.Replace("??????", machineName);

        services.AddDbContext<MasterDataContext>(opts =>
            opts.UseSqlServer(ConnectionString));
    }
}
