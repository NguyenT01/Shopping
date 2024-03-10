using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OrderingService.ORM.Dapper;
using OrderingService.ORM.EF;
using System.Data;

namespace OrderingService;

public static class ServiceExtension
{
    public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration config)
    {
        var ConnectionString = getConnectionString(config);

        services.AddDbContext<OrderingContext>(opts =>
            opts.UseSqlServer(ConnectionString));
    }
    public static void ConfigureDapperConnection(this IServiceCollection services, IConfiguration config)
    {
        var ConnectionString = getConnectionString(config);

        services.AddTransient<IDbConnection>(imp => new SqlConnection(ConnectionString));

        services.AddTransient<IOrderDapper, OrderDapper>();
        services.AddTransient<IOrderItemDapper, OrderItemDapper>();
    }

    private static string getConnectionString(IConfiguration config)
    {
        string? machineName = Environment.MachineName;
        string? ConnectionString = config["sqlConnection"];
        ConnectionString = ConnectionString!.Replace("??????", machineName);

        return ConnectionString;
    }
}
