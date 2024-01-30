using ProductServiceNamespace.ORM.EF.Interface;

namespace ProductServiceNamespace.ORM.EF
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ProductContext _repositoryContext;
        private readonly IProductRepository _productRepository;

        public RepositoryManager(ProductContext context)
        {
            _repositoryContext = context;
            _productRepository = new ProductRepository(context);
        }

        public IProductRepository Product => _productRepository;

        public async Task SaveAsync()
            => await _repositoryContext.SaveChangesAsync();
    }
}
