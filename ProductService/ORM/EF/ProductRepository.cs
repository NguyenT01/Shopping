using Microsoft.EntityFrameworkCore;
using ProductService.ORM.EF.Interface;
using ProductService.ORM.EF.Model;

namespace ProductService.ORM.EF
{
    public class ProductRepository : ProductRepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ProductRepositoryContext context) : base(context) { }

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
