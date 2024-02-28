using Consul;
using Microsoft.EntityFrameworkCore;
using OrderingService.ORM.EF;

namespace OrderingService;

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
        };

        await consulClient.Agent.ServiceRegister(consulRegistration);
    }

    public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration config)
    {
        //string? machineName = Environment.MachineName;
        //string? ConnectionString = config["sqlConnection"];
        //ConnectionString = ConnectionString!.Replace("??????", machineName);

        string? ConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

        services.AddDbContext<OrderingContext>(opts =>
            opts.UseSqlServer(ConnectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            }));
    }

    private static string? GetEnv(string env) => Environment.GetEnvironmentVariable(env);
}
