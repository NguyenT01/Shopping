using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using OrderingService.ORM.EF.Model;
using OrderingService.Protos;

namespace OrderingService
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region ORDERITEM
            CreateMap<OrderItem, ItemResponse>()
                .ForMember(d => d.OrderId, opts => opts.MapFrom(s => s.OrderId.ToString()))
                .ForMember(d => d.ProductId, opts => opts.MapFrom(s => s.ProductId.ToString()));


            #endregion

            #region ORDER
            CreateMap<Order, OrderResponse>()
                .ForMember(d => d.OrderId, opts => opts.MapFrom(s => s.OrderId.ToString()))
                .ForMember(d => d.CustomerId, opts => opts.MapFrom(s => s.CustomerId.ToString()))
                .ForMember(d => d.OrderDate, opts => opts.MapFrom(s => Timestamp.FromDateTime(
                    DateTime.SpecifyKind(s.OrderDate!.Value, DateTimeKind.Utc))));

            CreateMap<OrderCreationRequest, Order>()
                .ForMember(d => d.CustomerId, opts => opts.MapFrom(s => Guid.Parse(s.CustomerId)))
                .ForMember(d => d.OrderId, opts => opts.MapFrom(s => Guid.NewGuid()))
                .ForMember(d => d.OrderDate, opts => opts.MapFrom(s => s.OrderDate.ToDateTime()));

            CreateMap<OrderUpdateRequest, Order>()
                .ForMember(d => d.OrderDate, opts => opts.MapFrom(s => s.OrderDate.ToDateTime()))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            #endregion
        }
    }
}
