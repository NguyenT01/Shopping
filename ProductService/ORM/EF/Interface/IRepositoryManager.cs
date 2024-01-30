namespace ProductServiceNamespace.ORM.EF.Interface
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        Task SaveAsync();
    }
}
