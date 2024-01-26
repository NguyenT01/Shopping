using AutoMapper;
using MasterDataService.ORM.EF.Model;

namespace MasterDataService;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Customer, CustomerResponse>()
            .ForMember(d => d.CustomerId, opt => opt.MapFrom(x => x.CustomerId.ToString()));

    }
}
