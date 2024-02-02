using AutoMapper;
using Google.Protobuf.WellKnownTypes;
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

        public override async Task<ItemDecrementResponse> DecreaseQuantityOrderItemBy1(ItemRequest request, ServerCallContext context)
        {
            var itemEntity = await _checkAndGetItem(request.OrderId, request.ProductId, true);
            if (itemEntity.Quantity == 1)
            {
                _repository.OrderItem.DeleteItem(itemEntity);
                await _repository.SaveAsync();
                var response = new ItemDecrementResponse
                {
                    IsNull = true,
                };
                return response;
            }
            else
            {
                itemEntity.Quantity--;
            }

            await _repository.SaveAsync();
            var res = _mapper.Map<ItemDecrementResponse>(itemEntity);
            return res;
        }
        public override async Task<ItemResponse> IncreaseQuantityOrderItemBy1(ItemRequest request, ServerCallContext context)
        {
            var itemEntity = await _checkAndGetItem(request.OrderId, request.ProductId, true);
            itemEntity.Quantity += 1;
            await _repository.SaveAsync();

            return _mapper.Map<ItemResponse>(itemEntity);
        }
        public override async Task<Empty> UpdateOrderItem(OrderItemUpdateRequest request, ServerCallContext context)
        {
            var itemEntity = await _checkAndGetItem(request.OrderId, request.ProductId, true);
            _mapper.Map(request, itemEntity);
            await _repository.SaveAsync();
            return new Empty();
        }
        public override async Task<Empty> DeleteOrderItem(OrderItemDeletionRequest request, ServerCallContext context)
        {
            var itemEntity = await _checkAndGetItem(request.OrderId, request.ProductId, true);
            _repository.OrderItem.DeleteItem(itemEntity);
            await _repository.SaveAsync();
            return new Empty();
        }
        public override async Task<ItemResponse> CreateOrderItem(OrderItemCreationRequest request, ServerCallContext context)
        {
            var itemEntity = _mapper.Map<OrderItem>(request);
            _repository.OrderItem.AddItem(itemEntity);
            await _repository.SaveAsync();

            return _mapper.Map<ItemResponse>(itemEntity);
        }
        public override async Task<ItemListResponse> GetItemsFromOrder(OrderItemIdRequest request, ServerCallContext context)
        {
            var itemsEntity = await _repository.OrderItem.GetItemFromAnOrder(_parseGuid(request.OrderId), false);
            var items = _mapper.Map<IEnumerable<ItemResponse>>(itemsEntity);

            var res = new ItemListResponse();
            res.Items.AddRange(items);
            return res;
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
