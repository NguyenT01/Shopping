using Shopping.API.Protos.Manager;
using Shopping.API.Services;
using Shopping.API.Services.Interfaces;

namespace Shopping.API
{
    public static class ServiceExtensions
    {
        public static void ConfigureGrpcClient(this IServiceCollection services)
        {
            services.AddGrpcClient<CustomerProto.CustomerProtoClient>(opts =>
            {
                opts.Address = new Uri("https://localhost:7101");
            });
            services.AddGrpcClient<PriceProto.PriceProtoClient>(opts =>
            {
                opts.Address = new Uri("https://localhost:7102");
            });
            services.AddGrpcClient<ProductProto.ProductProtoClient>(opts =>
            {
                opts.Address = new Uri("https://localhost:7102");
            });
            services.AddGrpcClient<OrderProto.OrderProtoClient>(opts =>
            {
                opts.Address = new Uri("https://localhost:7103");
            });
            services.AddGrpcClient<OrderItemProto.OrderItemProtoClient>(opts =>
            {
                opts.Address = new Uri("https://localhost:7103");
            });

        }
        public static void ConfigureDIManager(this IServiceCollection services)
        {
            services.AddTransient<IProtosManager, ProtosManager>();
            services.AddTransient<IServiceManager, ServiceManager>();
        }
    }
}
