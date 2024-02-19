namespace Shopping.API.Services.Interfaces
{
    public interface IServiceManager
    {
        public IMasterDataService MasterDataService { get; }
        public IProductService ProductService { get; }
        public IPriceService PriceService { get; }
        public IOrderService OrderService { get; }
    }
}
