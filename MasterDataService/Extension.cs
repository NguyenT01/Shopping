using MasterDataService.ORM.Dapper;
using MasterDataService.ORM.EF;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MasterDataService;

public static class ServiceExtension
{
    public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration config)
    {
        string? ConnectionString = getConnectionString(config);

        services.AddDbContext<MasterDataContext>(opts =>
            opts.UseSqlServer(ConnectionString));
    }
    public static void ConfigureDapperConnection(this IServiceCollection services, IConfiguration config)
    {
        string? ConnectionString = getConnectionString(config);

        services.AddTransient<IDbConnection>(imp =>
                new SqlConnection(ConnectionString));

        services.AddTransient<ICustomerDapper, CustomerDapper>();
    }

    private static string getConnectionString(IConfiguration config)
    {
        string? machineName = Environment.MachineName;
        string? ConnectionString = config["sqlConnection"];
        ConnectionString = ConnectionString!.Replace("??????", machineName);

        return ConnectionString;
    }
}
