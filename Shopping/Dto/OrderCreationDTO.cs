namespace Shopping.API.Dto
{
    public class OrderCreationDTO
    {
        public Guid CustomerId { get; init; }
        public IEnumerable<OrderItemCreationWithoutOrderId>? Items { get; set; }

    }
}
