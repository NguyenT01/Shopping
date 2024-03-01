using Consul;
using Shopping.API.v1.Services;
using Shopping.API.v1.Services.Interfaces;
using System.Net;

namespace Shopping.API
{
    public static class ServiceExtensions
    {
        private static async Task<IList<string>> GetURIFromConsul(ConsulClient client, string serviceName)
        {
            IList<string> URIList = new List<string>();

            QueryResult<CatalogService[]> serviceTask = await client.Catalog.Service(serviceName);

            if (serviceTask.StatusCode == HttpStatusCode.OK)
            {
                foreach (var service in serviceTask.Response)
                {
                    string address = service.ServiceAddress;
                    string port = service.ServicePort.ToString();
                    string url = $"http://{address}:{port}";

                    URIList.Add(url);
                }
                if (URIList.Count > 0)
                    return URIList;
            }
            URIList.Add("http://0.0.0.0/9000");
            return URIList;
        }

        private static string? GetEnv(string envName)
            => Environment.GetEnvironmentVariable(envName);
        public static IHttpClientBuilder AddServiceDiscovery(this IHttpClientBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            builder.AddHttpMessageHandler(serviceProvicer =>
            {
                var consulClient = serviceProvicer.GetRequiredService<IConsulClient>();
                return new ConsulDiscoveryHttpMessageHandler(consulClient);
            });
            return builder;
        }

        public static void ConfigureGrpcClient(this IServiceCollection services)
        {

            services.AddGrpcClient<CustomerProto.CustomerProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                Uri MasterDataURI = new Uri("http://192.168.52.72:7101");
                opts.Address = MasterDataURI;
            });

            services.AddGrpcClient<PriceProto.PriceProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri("http://192.168.52.72:7102");
            });

            services.AddGrpcClient<ProductProto.ProductProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri("http://192.168.52.72:7102");
            });

            services.AddGrpcClient<OrderProto.OrderProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri("http://192.168.52.72:7103");
            });

            services.AddGrpcClient<OrderItemProto.OrderItemProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri("http://192.168.52.72:7103");
            });

        }
        public static void ConfigureDIManager(this IServiceCollection services)
        {
            services.AddTransient<IServiceManager, ServiceManager>();
        }
        private static void ConfigureHttpSupport()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", true);
        }
    }

}
