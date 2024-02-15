using AutoMapper;
using Shopping.API.Services.Interfaces;

namespace Shopping.API.Services;

public class ServiceManager : IServiceManager
{
    public IMasterDataService MasterDataService { get; }

    public ServiceManager(IMapper mapper, CustomerProto.CustomerProtoClient CustomerProto)
    {
        MasterDataService = new MasterDataService(mapper, CustomerProto);
    }
}
