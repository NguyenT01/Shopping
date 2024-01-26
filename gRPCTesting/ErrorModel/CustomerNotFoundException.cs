namespace MasterDataService.ErrorModel
{
    public sealed class CustomerNotFoundException : NotFoundException
    {
        public CustomerNotFoundException(Guid id) :
            base($"CustomerID {id} not found")
        { }
    }
}
