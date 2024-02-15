using AutoMapper;
using Shopping.API.Dto;

namespace Shopping.API;

public class MappingProfle : Profile
{
    public MappingProfle()
    {
        CreateMap<CustomerCreationDTO, CustomerCreationRequest>();
        CreateMap<CustomerUpdateDTO, CustomerUpdateRequest>()
            .ForMember(des => des.CustomerId, opt => opt.MapFrom(src => src.CustomerId.ToString()))
            .ForMember(des => des.Tracking, opt => opt.MapFrom(src => true));

    }
}
