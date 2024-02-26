using MasterDataService.ORM.EF;
using Microsoft.EntityFrameworkCore;

namespace MasterDataService;

public static class ServiceExtension
{
    public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration config)
    {
        //string? machineName = Environment.MachineName;
        //string? ConnectionString = config["sqlConnection"];
        //ConnectionString = ConnectionString!.Replace("??????", machineName);

        string? ConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

        System.Diagnostics.Debug.WriteLine("---> " + ConnectionString);



        services.AddDbContext<MasterDataContext>(opts =>
            opts.UseSqlServer(ConnectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            }));
    }
}
