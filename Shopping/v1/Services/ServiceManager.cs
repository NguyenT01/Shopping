using AutoMapper;
using Shopping.API.v1.Services.Interfaces;

namespace Shopping.API.v1.Services;

public class ServiceManager : IServiceManager
{
    public IMasterDataService MasterDataService { get; }
    public IProductService ProductService { get; }
    public IPriceService PriceService { get; }
    public IOrderService OrderService { get; }
    public IOrderItemService OrderItemService { get; }

    public ServiceManager(IMapper mapper, CustomerProto.CustomerProtoClient customerProto, ProductProto.ProductProtoClient productProto,
            PriceProto.PriceProtoClient price, OrderProto.OrderProtoClient order,
            OrderItemProto.OrderItemProtoClient orderItemProto)
    {
        MasterDataService = new MasterDataService(mapper, customerProto);
        ProductService = new ProductService(mapper, productProto, price);
        PriceService = new PriceService(mapper, price);
        OrderService = new OrderService(mapper, order, orderItemProto);
        OrderItemService = new OrderItemService(mapper, orderItemProto);
    }
}
