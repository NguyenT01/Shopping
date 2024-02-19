namespace Shopping.API.ErrorModel
{
    public class ItemNotFoundException : NotFoundException
    {
        public ItemNotFoundException(Guid orderId, Guid productId)
            : base($"Item OID: {orderId} -PID: {productId} not found") { }
    }
}
