using AutoMapper;
using Shopping.API.Protos.Manager;
using Shopping.API.Services.Interfaces;

namespace Shopping.API.Services;

public class ServiceManager : IServiceManager
{
    public IMasterDataService MasterDataService { get; }
    public IProductService ProductService { get; }
    public IPriceService PriceService { get; }
    public IOrderService OrderService { get; }
    public IOrderItemService OrderItemService { get; }

    public ServiceManager(IMapper mapper, IProtosManager protosManager)
    {
        MasterDataService = new MasterDataService(mapper, protosManager);
        ProductService = new ProductService(mapper, protosManager);
        PriceService = new PriceService(mapper, protosManager);
        OrderService = new OrderService(mapper, protosManager);
        OrderItemService = new OrderItemService(mapper, protosManager);
    }
}
