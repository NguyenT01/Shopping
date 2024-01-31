
using ProductServiceNamespace.ORM.EF.Interface;

namespace ProductServiceNamespace.ORM.EF
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ProductContext _repositoryContext;
        private readonly IProductRepository _productRepository;
        private readonly IPriceRepository _priceRepository;

        public RepositoryManager(ProductContext context)
        {
            _repositoryContext = context;
            _productRepository = new ProductRepository(context);
            _priceRepository = new PriceRepository(context);
        }

        public IProductRepository Product => _productRepository;
        public IPriceRepository Price => _priceRepository;

        public async Task SaveAsync()
            => await _repositoryContext.SaveChangesAsync();
    }
}
