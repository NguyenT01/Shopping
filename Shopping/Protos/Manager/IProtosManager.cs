namespace Shopping.API.Protos.Manager
{
    public interface IProtosManager
    {
        public CustomerProto.CustomerProtoClient Customer { get; }
        public ProductProto.ProductProtoClient Product { get; }
        public PriceProto.PriceProtoClient Price { get; }
    }
}
