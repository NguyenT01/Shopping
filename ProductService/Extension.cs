using Consul;
using Microsoft.EntityFrameworkCore;
using ProductServiceNamespace.ORM.EF;

namespace ProductServiceNamespace;

public static class ServiceExtension
{
    public static async Task ConfigureConsulClient(this IServiceCollection services)
    {
        var consulClient = new ConsulClient(config =>
        {
            config.Address = new Uri(GetEnv("CONSUL_SERVER_URI")!);
        });

        var consulRegistration = new AgentServiceRegistration()
        {
            ID = GetEnv("SERVICE_ID"),
            Name = GetEnv("SERVICE_NAME"),
            Address = GetEnv("IP_1"),
            Port = int.Parse(GetEnv("PORT_1")!),
            Tags = new string[] { "grpc" }
        };

        await consulClient.Agent.ServiceRegister(consulRegistration);
    }

    public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration config)
    {
        //string? machineName = Environment.MachineName;
        //string? ConnectionString = config["sqlConnection"];
        //ConnectionString = ConnectionString!.Replace("??????", machineName);

        string? ConnectionString = GetEnv("DB_CONNECTION_STRING");

        services.AddDbContext<ProductContext>(opts =>
            opts.UseSqlServer(ConnectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            }));
    }

    private static string? GetEnv(string env)
        => Environment.GetEnvironmentVariable(env);
}
