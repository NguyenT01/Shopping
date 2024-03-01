using Consul;

namespace Shopping.API
{
    public static class ConsulExtension
    {
        public static async Task<string> GetUriOnConsul(this IConsulClient consulClient, string serviceName)
        {
            if (consulClient is null)
                throw new ArgumentNullException(nameof(consulClient));

            serviceName = serviceName.Trim();

            var services = await consulClient.Agent.Services();
            var targets = services.Response
                           .Values
                           .Where(x => x.Service == serviceName)
                           .Select(x => $"http://{x.Address}:{x.Port}")
                           .ToList();

            var choice = new Random().Next(targets.Count);
            return targets[choice];

        }
        public static IServiceCollection AddConsul(this IServiceCollection services, string addressConsul)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                consulConfig.Address = new Uri(addressConsul);
            }));

            return services;
        }
    }
}
