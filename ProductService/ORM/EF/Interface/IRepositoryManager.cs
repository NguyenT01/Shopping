namespace ProductService.ORM.EF.Interface
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        Task SaveAsync();
    }
}
