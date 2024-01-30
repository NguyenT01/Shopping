using AutoMapper;
using ProductServiceNamespace.ORM.EF.Model;
using ProductServiceNamespace.Protos;

namespace ProductServiceNamespace
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductResponse>()
                .ForMember(d => d.ProductId, opts => opts.MapFrom(s => s.ProductId.ToString()));

            CreateMap<AddProductRequest, Product>();

            CreateMap<UpdateProductRequest, Product>()
                .ForMember(d => d.ProductId, opts => opts.MapFrom(s => Guid.Parse(s.ProductId)))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMembers) => srcMembers != null));
        }
    }
}
