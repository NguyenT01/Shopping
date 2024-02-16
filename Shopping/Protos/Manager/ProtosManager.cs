namespace Shopping.API.Protos.Manager
{
    public class ProtosManager : IProtosManager
    {
        public CustomerProto.CustomerProtoClient Customer { get; }

        public ProductProto.ProductProtoClient Product { get; }

        public PriceProto.PriceProtoClient Price { get; }


        public ProtosManager(CustomerProto.CustomerProtoClient customerProto, ProductProto.ProductProtoClient productProto,
            PriceProto.PriceProtoClient price)
        {
            Customer = customerProto;
            Product = productProto;
            Price = price;
        }
    }
}
