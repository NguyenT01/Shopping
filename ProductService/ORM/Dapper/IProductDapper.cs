using ProductServiceNamespace.ORM.EF.Model;

namespace ProductServiceNamespace.ORM.Dapper
{
    public interface IProductDapper
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product?> GetProduct(Guid id);
    }
}
