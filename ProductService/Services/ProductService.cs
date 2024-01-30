using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ProductServiceNamespace.ErrorModel;
using ProductServiceNamespace.ORM.EF.Interface;
using ProductServiceNamespace.ORM.EF.Model;
using ProductServiceNamespace.Protos;

namespace ProductServiceNamespace.Services
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

        public override async Task<ProductListResponse> GetProductList(Empty request, ServerCallContext context)
        {
            var productEntityList = await _repository.Product.GetAllProducts(false);
            var productList = _mapper.Map<IEnumerable<ProductResponse>>(productEntityList);

            var response = new ProductListResponse();
            response.Products.AddRange(productList);

            return response;
        }

        public override async Task<Empty> UpdateProduct(UpdateProductRequest request, ServerCallContext context)
        {
            var productEntity = await checkProductIdAsync(parseToGuid(request.ProductId), true);
            _mapper.Map(request, productEntity);
            await _repository.SaveAsync();

            return new Empty();
        }

        public override async Task<Empty> DeleteProduct(DeleteProductRequest request, ServerCallContext context)
        {
            var productEntity = await checkProductIdAsync(parseToGuid(request.ProductId), true);
            _repository.Product.DeleteProduct(productEntity);
            await _repository.SaveAsync();

            return new Empty();
        }

        public override async Task<ProductResponse> AddProduct(AddProductRequest request, ServerCallContext context)
        {
            var productEntity = _mapper.Map<Product>(request);
            _repository.Product.CreateProduct(productEntity);
            await _repository.SaveAsync();

            var productReturn = _mapper.Map<ProductResponse>(productEntity);
            return productReturn;
        }

        public override async Task<ProductResponse> GetProductById(ProductIdRequest request, ServerCallContext context)
        {
            Guid id = parseToGuid(request.ProductId);
            var product = await checkProductIdAsync(id, request.Tracking);

            var productResponse = _mapper.Map<ProductResponse>(product);
            return productResponse;
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
