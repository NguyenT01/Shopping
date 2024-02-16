using AutoMapper;
using Google.Protobuf.WellKnownTypes;
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

            CreateMap<AddProductRequest, Product>()
                .ForMember(d => d.ProductId, opts => opts.MapFrom(s => Guid.NewGuid()));

            CreateMap<UpdateProductRequest, Product>()
                .ForMember(d => d.ProductId, opts => opts.MapFrom(s => Guid.Parse(s.ProductId)))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMembers) => srcMembers != null));

            //--- PRICE
            CreateMap<Price, PriceResponse>()
                .ForMember(d => d.ProductId, opts => opts.MapFrom(s => s.ProductId.ToString()))
                .ForMember(d => d.PriceId, opts => opts.MapFrom(s => s.PriceId.ToString()))
                .ForMember(d => d.PriceValue, opts => opts.MapFrom(s => Math.Round((decimal)s.PriceValue!, 2)))
                .ForMember(d => d.StartDate, opts => opts.MapFrom(s => Timestamp.FromDateTime(DateTime.SpecifyKind(s.StartDate!.Value, DateTimeKind.Utc))))
                .ForMember(d => d.EndDate, opts => opts.MapFrom(s => Timestamp.FromDateTime(DateTime.SpecifyKind(s.EndDate!.Value, DateTimeKind.Utc))));

            CreateMap<PriceCreationRequest, Price>()
                .ForMember(d => d.StartDate, opts => opts.MapFrom(s => s.StartDate.ToDateTime()))
                .ForMember(d => d.EndDate, opts => opts.MapFrom(s => s.EndDate.ToDateTime()))
                .ForMember(d => d.PriceId, opts => opts.MapFrom(s => Guid.NewGuid()));

            CreateMap<PriceUpdateRequest, Price>()
                .ForMember(d => d.PriceId, opts => opts.MapFrom(s => Guid.Parse(s.PriceId)))
                .ForMember(d => d.StartDate, opts => opts.MapFrom(s => s.StartDate.ToDateTime()))
                .ForMember(d => d.EndDate, opts => opts.MapFrom(s => s.EndDate.ToDateTime()))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        }
    }

}
