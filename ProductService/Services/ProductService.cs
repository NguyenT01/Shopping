using AutoMapper;
using Grpc.Core;
using ProductService.ErrorModel;
using ProductService.ORM.EF.Interface;
using ProductService.ORM.EF.Model;
using ProductService.Protos;

namespace ProductService.Services
{
    public class ProductService : ProductProto.ProductProtoBase
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repository;

        public ProductService(ILogger<ProductService> logger, IMapper mapper, IRepositoryManager repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public override async Task<ProductResponse> GetProductById(ProductIdRequest request, ServerCallContext context)
        {
            Guid id = parseToGuid(request.ProductId);
            var product = await checkProductIdAsync(id, request.Tracking);



            return null;
        }

        // PRIVATE METHODS
        private Guid parseToGuid(string id)
        {
            Guid guid;
            bool parseId = Guid.TryParse(id, out guid);
            if (!parseId)
                throw new IDInvalidException("ID format is not valid");
            return guid;
        }
        private async Task<Product> checkProductIdAsync(Guid id, bool tracking)
        {
            var product = await _repository.Product.GetProduct(id, tracking);
            if (product is null)
                throw new ProductNotFoundException(id);
            return product;
        }
    }
}
