using Microsoft.EntityFrameworkCore;
using ProductServiceNamespace.ORM.EF.Interface;
using ProductServiceNamespace.ORM.EF.Model;

namespace ProductServiceNamespace.ORM.EF
{
    public class ProductRepository : ProductRepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ProductContext context) : base(context) { }

        public void CreateProduct(Product product)
            => Add(product);

        public void DeleteProduct(Product product)
            => Delete(product);

        public async Task<IEnumerable<Product>> GetAllProducts(bool tracking)
            => await FindAll(tracking)
            .OrderBy(p => p.Name)
            .ThenBy(p => p.Description)
            .ToListAsync();

        public async Task<Product?> GetProduct(Guid id, bool tracking)
            => await FindByCondition(p => p.ProductId.Equals(id), tracking)
            .SingleOrDefaultAsync();
    }
}
