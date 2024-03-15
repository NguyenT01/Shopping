using AspNetCoreRateLimit;
using FluentValidation;
using FluentValidation.AspNetCore;
using Shopping.API.v1.Services;
using Shopping.API.v1.Services.Interfaces;
using System.Reflection;

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

        // Add Rate Limit
        public static void ConfigureRateLimiting(this IServiceCollection services, IConfiguration config)
        {
            var rateLimitConfig = config.GetSection("RateLimiting");

            var rateLimitRules = new List<RateLimitRule>
            {
                new RateLimitRule
                {
                    Endpoint = rateLimitConfig.GetSection("HostsAllowed").Value,
                    Limit = int.Parse(rateLimitConfig.GetSection("RequestLimit").Value!),
                    Period = rateLimitConfig.GetSection("RetryTime").Value
                }
            };

            services.AddMemoryCache();
            services.Configure<IpRateLimitOptions>(opt =>
            {
                opt.GeneralRules = rateLimitRules;
            });
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
        }

        // Auto Validation with FluentValidation
        public static void ConfigureFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
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
