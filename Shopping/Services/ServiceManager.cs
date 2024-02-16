using AutoMapper;
using Shopping.API.Protos.Manager;
using Shopping.API.Services.Interfaces;

namespace Shopping.API.Services;

public class ServiceManager : IServiceManager
{
    public IMasterDataService MasterDataService { get; }
    public IProductService ProductService { get; }

    public ServiceManager(IMapper mapper, IProtosManager protosManager)
    {
        MasterDataService = new MasterDataService(mapper, protosManager);
        ProductService = new ProductService(mapper, protosManager);
    }
}
