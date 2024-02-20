using Shopping.API.Protos.Manager;
using Shopping.API.v1.Services;
using Shopping.API.v1.Services.Interfaces;

namespace Shopping.API
{
    public static class ServiceExtensions
    {
        public static void ConfigureGrpcClient(this IServiceCollection services)
        {
            services.AddGrpcClient<CustomerProto.CustomerProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri("https://localhost:7101");
            });
            services.AddGrpcClient<PriceProto.PriceProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri("https://localhost:7102");
            });
            services.AddGrpcClient<ProductProto.ProductProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri("https://localhost:7102");
            });
            services.AddGrpcClient<OrderProto.OrderProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri("https://localhost:7103");
            });
            services.AddGrpcClient<OrderItemProto.OrderItemProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri("https://localhost:7103");
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
