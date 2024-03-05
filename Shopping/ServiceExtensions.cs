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
        //public static IHttpClientBuilder AddServiceDiscovery(this IHttpClientBuilder builder, string serviceName)
        //{
        //    builder.Services.TryAddSingleton<ConsulDiscoveryHttpMessageHandler>();
        //    if (builder == null)
        //    {
        //        throw new ArgumentNullException(nameof(builder));
        //    }
        //    builder.AddHttpMessageHandler(serviceProvicer =>
        //    {
        //        //var consulClient = serviceProvicer.GetRequiredService<IConsulClient>();
        //        //return new ConsulDiscoveryHttpMessageHandler(consulClient, serviceName);
        //    });
        //    return builder;
        //}

        public static void ConfigureGrpcClient(this IServiceCollection services)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", true);
            services.AddTransient<ConsulDiscoveryHttpMessageHandler>();
            services.AddGrpcClient<CustomerProto.CustomerProtoClient>("masterdata", opts =>
            {
                //ConfigureHttpSupport();
                //var consulClient = serviceProvider.GetRequiredService<IConsulClient>();
                opts.Address = new Uri("http://localhost");
                //opts.Address = new Uri(consulClient.GetUriOnConsul("masterdata").Result);
            }).AddHttpMessageHandler(cfg =>
            {
                var consulClient = cfg.GetRequiredService<IConsulClient>();
                var consulDiscoveryHttpMessageHandler = cfg.GetRequiredService<ConsulDiscoveryHttpMessageHandler>();
                consulDiscoveryHttpMessageHandler.ServiceName = "masterdata";
                return consulDiscoveryHttpMessageHandler;
            });



            //AddServiceDiscovery("masterdata");


            services.AddGrpcClient<PriceProto.PriceProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri("http://192.168.57.84:7101");
            });

            services.AddGrpcClient<ProductProto.ProductProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri("http://192.168.57.84:7101");
            });

            services.AddGrpcClient<OrderProto.OrderProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri("http://192.168.57.84:7101");
            });

            services.AddGrpcClient<OrderItemProto.OrderItemProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri("http://192.168.57.84:7101");
            });


        }
        public static void ConfigureDIManager(this IServiceCollection services)
        {
            services.AddTransient<IServiceManager, ServiceManager>();
        }
        private static void ConfigureHttpSupport()
        {

        }
    }

}
