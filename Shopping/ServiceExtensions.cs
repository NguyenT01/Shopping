using Consul;
using Shopping.API.Protos.Manager;
using Shopping.API.v1.Services;
using Shopping.API.v1.Services.Interfaces;
using System.Net;

namespace Shopping.API
{
    public static class ServiceExtensions
    {
        public static async Task ConfigureGrpcClient(this IServiceCollection services)
        {
            var consulClient = new ConsulClient(conf => conf.Address = new Uri("http://192.168.56.40:8500"));

            QueryResult<CatalogService[]> masterdataServiceTask = await consulClient.Catalog.Service("MasterDataService1");

            IList<string> URI_MASTERDATA = new List<string>();

            if (masterdataServiceTask.StatusCode == HttpStatusCode.OK)
            {
                foreach (var service in masterdataServiceTask.Response)
                {
                    string address = service.ServiceAddress;
                    string port = service.ServicePort.ToString();

                    string url = $"http://{address}:{port}";
                    URI_MASTERDATA.Append(url);
                    Console.WriteLine("---> " + url);
                }
            }



            //string? URI_MASTERDATA = Environment.GetEnvironmentVariable("URI_MASTERDATA");
            string? URI_PRODUCT = Environment.GetEnvironmentVariable("URI_PRODUCT");
            string? URI_ORDER = Environment.GetEnvironmentVariable("URI_ORDER");


            services.AddGrpcClient<CustomerProto.CustomerProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri(URI_MASTERDATA[0]);
            });
            services.AddGrpcClient<PriceProto.PriceProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri(URI_PRODUCT!);
            });
            services.AddGrpcClient<ProductProto.ProductProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri(URI_PRODUCT!);
            });
            services.AddGrpcClient<OrderProto.OrderProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri(URI_ORDER!);
            });
            services.AddGrpcClient<OrderItemProto.OrderItemProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri(URI_ORDER!);
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
