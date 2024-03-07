using AutoMapper;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Shopping.API.Dto;
using Shopping.API.v1.Services.Interfaces;

namespace Shopping.API.v1.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly ProductProto.ProductProtoClient productProto;
        private readonly PriceProto.PriceProtoClient priceProto;

        public ProductService(IMapper mapper, ProductProto.ProductProtoClient productProto, PriceProto.PriceProtoClient priceProto)
        {
            _mapper = mapper;
            this.productProto = productProto;
            this.priceProto = priceProto;
        }

        public async Task<ProductDTO> AddProduct(ProductCreationDTO productCreationDTO)
        {
            var productRequest = _mapper.Map<AddProductRequest>(productCreationDTO);
            var product = await productProto.AddProductAsync(productRequest);

            productCreationDTO.ProductId = Guid.Parse(product.ProductId);

            if (productCreationDTO.StartDate.Equals(DateTime.MinValue))
                productCreationDTO.StartDate = DateTime.Now;
            if (productCreationDTO.EndDate.Equals(DateTime.MinValue))
                productCreationDTO.EndDate = DateTime.MaxValue;

            var priceRequest = _mapper.Map<PriceCreationRequest>(productCreationDTO);
            var price = await priceProto.CreateNewPriceAsync(priceRequest);

            var productDTO = _mapper.Map<ProductDTO>(product);
            productDTO = _mapper.Map(price, productDTO);

            return productDTO;
        }

        public async Task DeleteProduct(Guid pid)
        {
            var productIDRequest = new SingleProductIdRequest()
            {
                ProductId = pid.ToString()
            };

            await priceProto.DeletePriceByProductIdAsync(productIDRequest);

            var productIdRequest2 = _mapper.Map<DeleteProductRequest>(productIDRequest);

            await productProto.DeleteProductAsync(productIdRequest2);
        }

        public async Task<ProductDTO> GetProductById(Guid pid)
        {
            var productId = new ProductIdRequest()
            {
                ProductId = pid.ToString(),
                Tracking = false
            };

            var product = await productProto.GetProductByIdAsync(productId);
            var price = await priceProto.GetCurrentPriceAsync(_mapper.Map<SingleProductIdRequest>(productId));

            var productDTO = _mapper.Map<ProductResponse, ProductDTO>(product);
            productDTO = _mapper.Map(price, productDTO);

            return productDTO;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductList()
        {
            var productsResponse = await productProto.GetProductListAsync(new Empty());
            var products = productsResponse.Products;

            var productDTOList = _mapper.Map<RepeatedField<ProductResponse>, IList<ProductDTO>>(products);

            for (int i = 0; i < productDTOList.Count; i++)
            {
                var product = productDTOList[i];

                var pid = new ProductIdRequest()
                {
                    ProductId = product.ProductId.ToString(),
                    Tracking = false
                };

                var price = await priceProto.GetCurrentPriceAsync(_mapper.Map<SingleProductIdRequest>(pid));
                product = _mapper.Map(price, product);

                productDTOList[i] = product;
            }

            return productDTOList.AsEnumerable();
        }

        public async Task UpdateProduct(ProductUpdateDTO productDTO)
        {
            var product = _mapper.Map<UpdateProductRequest>(productDTO);
            await productProto.UpdateProductAsync(product);

            var productIdRequest = _mapper.Map<SingleProductIdRequest>(productDTO);
            var currentPrice = await priceProto.GetCurrentPriceAsync(productIdRequest);

            var priceUpdate = _mapper.Map<PriceUpdateRequest>(currentPrice);
            priceUpdate = _mapper.Map(productDTO, priceUpdate);
            await priceProto.UpdatePriceAsync(priceUpdate);
        }

        #region PRIVATE FUNCTIONS

        #endregion
    }
}
