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

            var services = await consulClient.Agent.Services().ConfigureAwait(false);
            var targets = services.Response
                           .Values
                           .Where(x => x.Service == serviceName)
                           .Select(x => $"http://{x.Address}:{x.Port}")
                           .ToList();

            var choice = new Random().Next(targets.Count);
            return targets[choice];

        }
        public static IServiceCollection AddConsul(this IServiceCollection services)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                consulConfig.Address = new Uri("http://192.168.57.84:8500");
            }));

            return services;
        }

        private static string? GetEnv(string envName)
            => Environment.GetEnvironmentVariable(envName);
    }
}
