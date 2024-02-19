using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Shopping.API.Dto;

namespace Shopping.API;

public class MappingProfle : Profile
{
    public MappingProfle()
    {
        #region MASTERDATA(CUSTOMER)
        CreateMap<CustomerCreationDTO, CustomerCreationRequest>();
        CreateMap<CustomerUpdateDTO, CustomerUpdateRequest>()
            .ForMember(des => des.CustomerId, opt => opt.MapFrom(src => src.CustomerId.ToString()))
            .ForMember(des => des.Tracking, opt => opt.MapFrom(src => true));

        #endregion

        #region PRODUCT, PRICE
        CreateMap<ProductIdRequest, SingleProductIdRequest>();
        CreateMap<ProductResponse, ProductDTO>()
            .ForMember(d => d.ProductId, opt => opt.MapFrom(s => Guid.Parse(s.ProductId)))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMem) => srcMem != null));
        CreateMap<PriceResponse, ProductDTO>()
            .ForMember(d => d.StartDate, opt => opt.MapFrom(s => s.StartDate.ToDateTime()))
            .ForMember(d => d.EndDate, opt => opt.MapFrom(s => s.EndDate.ToDateTime()))
            .ForMember(d => d.ProductId, opt => opt.Ignore())
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<ProductCreationDTO, AddProductRequest>();
        CreateMap<PriceCreationDTO, PriceCreationRequest>()
            .ForMember(d => d.ProductId, opt => opt.MapFrom(s => s.ProductId.ToString()))
            .ForMember(d => d.StartDate, opt => opt.MapFrom(s =>
                 Timestamp.FromDateTime(DateTime.SpecifyKind(s.StartDate, DateTimeKind.Utc))))
            .ForMember(d => d.EndDate, opt => opt.MapFrom(s =>
                 Timestamp.FromDateTime(DateTime.SpecifyKind(s.EndDate, DateTimeKind.Utc))));

        CreateMap<SingleProductIdRequest, DeleteProductRequest>();

        CreateMap<PriceResponse, PriceDTO>()
            .ForMember(d => d.StartDate, opt => opt.MapFrom(s => s.StartDate.ToDateTime()))
            .ForMember(d => d.EndDate, opt => opt.MapFrom(s => s.EndDate.ToDateTime()))
            .ForMember(d => d.ProductId, opt => opt.MapFrom(s => Guid.Parse(s.ProductId)))
            .ForMember(d => d.PriceId, opt => opt.MapFrom(s => Guid.Parse(s.PriceId)))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


        #region UPDATE
        CreateMap<ProductUpdateDTO, UpdateProductRequest>()
            .ForMember(d => d.ProductId, opt => opt.MapFrom(s => s.ProductId.ToString()));
        CreateMap<ProductUpdateDTO, SingleProductIdRequest>()
            .ForMember(d => d.ProductId, opt => opt.MapFrom(s => s.ProductId.ToString()));
        CreateMap<PriceResponse, PriceUpdateRequest>()
            .ForMember(d => d.PriceId, opt => opt.MapFrom(s => s.PriceId.ToString()))
             .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<ProductUpdateDTO, PriceUpdateRequest>()
            .ForMember(d => d.StartDate, opt => opt.MapFrom(s =>
                    Timestamp.FromDateTime(DateTime.SpecifyKind(s.StartDate, DateTimeKind.Utc))))
            .ForMember(d => d.EndDate, opt => opt.MapFrom(s =>
                    Timestamp.FromDateTime(DateTime.SpecifyKind(s.EndDate, DateTimeKind.Utc))))
            .ForMember(d => d.PriceValue, opt => opt.MapFrom(s => (s.PriceValue > 0) ? s.PriceValue : 999_999_999));

        CreateMap<PriceUpdateDTO, PriceUpdateRequest>()
            .ForMember(d => d.PriceId, opt => opt.MapFrom(s => s.PriceId.ToString()))
            .ForMember(d => d.StartDate, opt => opt.MapFrom(s =>
                 Timestamp.FromDateTime(DateTime.SpecifyKind(s.StartDate, DateTimeKind.Utc))))
            .ForMember(d => d.EndDate, opt => opt.MapFrom(s =>
                 Timestamp.FromDateTime(DateTime.SpecifyKind(s.EndDate, DateTimeKind.Utc))));

        #endregion

        #endregion

        #region ORDER, ORDER_ITEM
        CreateMap<OrderResponse, OrderDTO>()
            .ForMember(d => d.OrderId, opt => opt.MapFrom(s => Guid.Parse(s.OrderId)))
            .ForMember(d => d.CustomerId, opt => opt.MapFrom(s => Guid.Parse(s.CustomerId)))
            .ForMember(d => d.OrderDate, opt => opt.MapFrom(s => s.OrderDate.ToDateTime()));

        CreateMap<OrderCreationDTO, OrderCreationRequest>()
            .ForMember(d => d.CustomerId, opt => opt.MapFrom(s => s.CustomerId.ToString()))
            .ForMember(d => d.OrderDate, opt => opt.MapFrom(s =>
                Timestamp.FromDateTime(DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc))));

        CreateMap<OrderItemCreationWithoutOrderId, OrderItemCreationRequest>()
            .ForMember(d => d.ProductId, opt => opt.MapFrom(s => s.ProductId.ToString()))
            .ForMember(d => d.OrderId, opt => opt.Ignore());

        CreateMap<ItemResponse, OrderItemDeletionRequest>();
        CreateMap<OrderItemIdRequest, OrderIdRequest>();

        #endregion

    }
}
