namespace ProductServiceNamespace.ORM.EF.Interface
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        IPriceRepository Price { get; }
        Task SaveAsync();
    }
}
