using Consul;
using Shopping.API.Protos.Manager;
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

        public static async Task ConfigureGrpcClient(this IServiceCollection services)
        {
            var consulClient = new ConsulClient(conf => conf.Address = new Uri(GetEnv("CONSUL_SERVER")!));

            IList<string> URI_MASTERDATA = await GetURIFromConsul(consulClient, GetEnv("MASTERDATA_SERVICE_CONSUL")!);
            IList<string> URI_PRODUCT = await GetURIFromConsul(consulClient, GetEnv("PRODUCT_SERVICE_CONSUL")!);
            IList<string> URI_ORDER = await GetURIFromConsul(consulClient, GetEnv("ORDER_SERVICE_CONSUL")!);

            services.AddGrpcClient<CustomerProto.CustomerProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                Uri MasterDataURI = new Uri(URI_MASTERDATA.FirstOrDefault()!);
                opts.Address = MasterDataURI;
            });
            services.AddGrpcClient<PriceProto.PriceProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri(URI_PRODUCT.FirstOrDefault()!);
            });
            services.AddGrpcClient<ProductProto.ProductProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri(URI_PRODUCT.FirstOrDefault()!);
            });
            services.AddGrpcClient<OrderProto.OrderProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri(URI_ORDER.FirstOrDefault()!);
            });
            services.AddGrpcClient<OrderItemProto.OrderItemProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri(URI_ORDER.FirstOrDefault()!);
            });

        }
        public static void ConfigureDIManager(this IServiceCollection services)
        {
            services.AddTransient<IProtosManager, ProtosManager>();
            services.AddTransient<IServiceManager, ServiceManager>();
        }
        private static void ConfigureHttpSupport()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", true);
        }
    }

}
