using Shopping.API.v1.Services;
using Shopping.API.v1.Services.Interfaces;

namespace Shopping.API
{
    public static class ServiceExtensions
    {
        public static void ConfigureGrpcClient(this IServiceCollection services, IConfiguration conf)
        {
            services.AddGrpcClient<CustomerProto.CustomerProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri(conf.GetSection("gRPCAddress:MasterData").Value!);
            });
            services.AddGrpcClient<PriceProto.PriceProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri(conf.GetSection("gRPCAddress:Product").Value!);
            });
            services.AddGrpcClient<ProductProto.ProductProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri(conf.GetSection("gRPCAddress:Product").Value!);
            });
            services.AddGrpcClient<OrderProto.OrderProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri(conf.GetSection("gRPCAddress:Ordering").Value!);
            });
            services.AddGrpcClient<OrderItemProto.OrderItemProtoClient>(opts =>
            {
                ConfigureHttpSupport();
                opts.Address = new Uri(conf.GetSection("gRPCAddress:Ordering").Value!);
            });

        }
        public static void ConfigureDIManager(this IServiceCollection services)
        {
            // services.AddTransient<IProtosManager, ProtosManager>();
            services.AddTransient<IServiceManager, ServiceManager>();
        }
        private static void ConfigureHttpSupport()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", true);
        }
    }

}
