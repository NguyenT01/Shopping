using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductServiceNamespace.ORM.Dapper;
using ProductServiceNamespace.ORM.EF;
using System.Data;

namespace ProductServiceNamespace;

public static class ServiceExtension
{
    public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration config)
    {
        var ConnectionString = getConnectionString(config);

        services.AddDbContext<ProductContext>(opts =>
            opts.UseSqlServer(ConnectionString));
    }

    public static void ConfigureDapperConnection(this IServiceCollection services, IConfiguration config)
    {
        var ConnectionString = getConnectionString(config);

        services.AddTransient<IDbConnection>(imp => new SqlConnection(ConnectionString));

        services.AddTransient<IProductDapper, ProductDapper>();
        services.AddTransient<IPriceDapper, PriceDapper>();
    }

    private static string getConnectionString(IConfiguration config)
    {
        string? machineName = Environment.MachineName;
        string? ConnectionString = config["sqlConnection"];
        ConnectionString = ConnectionString!.Replace("??????", machineName);

        return ConnectionString;
    }
}
