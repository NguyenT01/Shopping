namespace Shopping.API.v1.Services.Interfaces
{
    public interface IServiceManager
    {
        public IMasterDataService MasterDataService { get; }
        public IProductService ProductService { get; }
        public IPriceService PriceService { get; }
        public IOrderService OrderService { get; }
        public IOrderItemService OrderItemService { get; }
    }
}
