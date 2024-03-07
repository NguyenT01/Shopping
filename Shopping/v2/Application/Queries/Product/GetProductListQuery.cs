using AutoMapper;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using MediatR;
using Shopping.API.Dto;

namespace Shopping.API.v2.Application.Queries.Product
{
    public class GetProductListQuery : IRequest<IEnumerable<ProductDTO>>
    {

    }

    public class GetProductListHandler : IRequestHandler<GetProductListQuery, IEnumerable<ProductDTO>>
    {
        private IMapper _mapper;
        private readonly ProductProto.ProductProtoClient productProto;
        private readonly PriceProto.PriceProtoClient priceProto;

        public GetProductListHandler(IMapper mapper, ProductProto.ProductProtoClient productProto, PriceProto.PriceProtoClient priceProto)
        {
            _mapper = mapper;
            this.productProto = productProto;
            this.priceProto = priceProto;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
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
    }
}
