using AutoMapper;
using Grpc.Core;
using OrderingService.ErrorModel;
using OrderingService.ORM.EF.Interface;
using OrderingService.ORM.EF.Model;
using OrderingService.Protos;

namespace OrderingService.Services
{
    public class OrderItemService : OrderItemProto.OrderItemProtoBase
    {
        private IOrderingRepositoryManager _repository;
        private IMapper _mapper;

        public OrderItemService(IMapper mapper, IOrderingRepositoryManager repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public override async Task<ItemResponse> GetItem(GetItemRequest request, ServerCallContext context)
        {
            var itemEntity = await _checkAndGetItem(request.OrderId, request.ProductId, false);
            return _mapper.Map<ItemResponse>(itemEntity);
        }

        #region PRIVATE METHODS
        private Guid _parseGuid(string id)
        {
            if (!Guid.TryParse(id, out Guid guid))
            {
                throw new IDInvalidException("id parse failed");
            }
            return guid;
        }
        private async Task<OrderItem> _checkAndGetItem(string orderId, string productId, bool tracking)
        {
            var oid = _parseGuid(orderId);
            var pid = _parseGuid(productId);
            var itemEntity = await _repository.OrderItem.GetItem(oid, pid, tracking);
            return itemEntity is not null ? itemEntity : throw new ItemNotFoundException(oid, pid);
        }
        #endregion

    }
}
