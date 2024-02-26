using Shopping.API.Protos.Manager;
using Shopping.API.v1.Services;
using Shopping.API.v1.Services.Interfaces;

namespace Shopping.API
{
    public static class ServiceExtensions
    {
        public static void ConfigureGrpcClient(this IServiceCollection services)
        {
            string? URI_MASTERDATA = Environment.GetEnvironmentVariable("URI_MASTERDATA");
            string? URI_PRODUCT = Environment.GetEnvironmentVariable("URI_PRODUCT");
            string? URI_ORDER = Environment.GetEnvironmentVariable("URI_ORDER");


            services.AddGrpcClient<CustomerProto.CustomerProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri(URI_MASTERDATA!);
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
