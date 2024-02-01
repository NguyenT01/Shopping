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
            CreateMap<Order, OrderResponse>()
                .ForMember(d => d.OrderId, opts => opts.MapFrom(s => s.OrderId.ToString()))
                .ForMember(d => d.CustomerId, opts => opts.MapFrom(s => s.CustomerId.ToString()))
                .ForMember(d => d.OrderDate, opts => opts.MapFrom(s => Timestamp.FromDateTime(
                    DateTime.SpecifyKind(s.OrderDate!.Value, DateTimeKind.Utc))));


        }
    }
}
