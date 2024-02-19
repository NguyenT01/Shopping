namespace Shopping.API.Protos.Manager
{
    public class ProtosManager : IProtosManager
    {
        public CustomerProto.CustomerProtoClient Customer { get; }

        public ProductProto.ProductProtoClient Product { get; }

        public PriceProto.PriceProtoClient Price { get; }

        public OrderProto.OrderProtoClient Order { get; }
        public OrderItemProto.OrderItemProtoClient OrderItem { get; }


        public ProtosManager(CustomerProto.CustomerProtoClient customerProto, ProductProto.ProductProtoClient productProto,
            PriceProto.PriceProtoClient price, OrderProto.OrderProtoClient order,
            OrderItemProto.OrderItemProtoClient orderItemProto)
        {
            Customer = customerProto;
            Product = productProto;
            Price = price;
            Order = order;
            OrderItem = orderItemProto;
        }
    }
}
