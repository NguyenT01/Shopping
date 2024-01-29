using ProductService.ORM.EF.Interface;

namespace ProductService.ORM.EF
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ProductRepositoryContext _repositoryContext;
        private readonly IProductRepository _productRepository;

        public RepositoryManager(ProductRepositoryContext context)
        {
            _repositoryContext = context;
            _productRepository = new ProductRepository(context);
        }

        public IProductRepository Product => _productRepository;

        public async Task SaveAsync()
            => await _repositoryContext.SaveChangesAsync();
    }
}
