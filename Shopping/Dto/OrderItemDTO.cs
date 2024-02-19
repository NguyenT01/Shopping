namespace Shopping.API.Dto
{
    public class OrderItemDTO
    {
        public Guid? OrderId { get; set; }
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }
    }
    public class OrderItemCreationDTO : OrderItemDTO { }
    public class OrderItemUpdateDTO : OrderItemCreationWithoutOrderId { }
    public class OrderItemCreationWithoutOrderId
    {
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }
    }
}
