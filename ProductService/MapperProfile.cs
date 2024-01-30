using AutoMapper;
using ProductService.ORM.EF.Model;
using ProductService.Protos;

namespace ProductService
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductResponse>()
                .ForMember()
        }
    }
}
