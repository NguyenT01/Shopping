using AutoMapper;
using MasterDataService.ORM.EF.Model;

namespace MasterDataService;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Customer, CustomerResponse>()
            .ForMember(d => d.CustomerId, opt => opt.MapFrom(x => x.CustomerId.ToString()));

        CreateMap<CustomerCreationRequest, Customer>()
            .ForMember(cus => cus.CustomerId, opt => opt.MapFrom(src => Guid.NewGuid()));

        CreateMap<CustomerUpdateRequest, Customer>()
            .ForMember(d => d.CustomerId, opt => opt.MapFrom(x => Guid.Parse(x.CustomerId)))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMembers) => srcMembers != null));
    }
}
