using ProductService.ORM.EF.Model;

namespace ProductService.ORM.EF.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts(bool tracking);
        Task<Product?> GetProduct(Guid id, bool tracking);
        void DeleteProduct(Product product);
        void CreateProduct(Product product);
    }
}
