using AutoMapper;
using Grpc.Core;
using OrderingService.ErrorModel;
using OrderingService.ORM.EF.Interface;
using OrderingService.ORM.EF.Model;
using OrderingService.Protos;

namespace OrderingService.Services;

public class OrderService : OrderProto.OrderProtoBase
{
    private IMapper _mapper;
    private IOrderingRepositoryManager _repository;

    public OrderService(IMapper mapper, IOrderingRepositoryManager repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public override async Task<OrderResponse> GetOrder(OrderIdRequest request, ServerCallContext context)
    {
        var orderEntity = await _checkAndGetOrder(_parseGuid(request.OrderId), false);
        return _mapper.Map<OrderResponse>(orderEntity);
    }


    //--- PRIVATE METHODS
    private async Task<Order> _checkAndGetOrder(Guid orderId, bool tracking)
    {
        var orderEntity = await _repository.Order.GetOrder(orderId, tracking) ?? throw new OrderNotFoundException(orderId);
        return orderEntity;
    }

    private Guid _parseGuid(string id)
    {
        if (!Guid.TryParse(id, out Guid guid))
        {
            throw new IDInvalidException("id parse failed");
        }
        return guid;
    }
}
