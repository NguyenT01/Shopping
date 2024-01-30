namespace ProductService.ErrorModel
{
    public sealed class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(Guid id) :
            base($"ProductID {id} not found")
        { }
    }
}
