using AutoMapper;
using MediatR;
using Shopping.API.Dto;

namespace Shopping.API.v2.Application.Queries.Product
{
    public class GetProductByIdQuery : IRequest<ProductDTO>
    {
        public Guid pid;
    }

    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDTO>
    {
        private readonly IMapper _mapper;
        private readonly ProductProto.ProductProtoClient productProto;
        private readonly PriceProto.PriceProtoClient priceProto;

        public GetProductByIdHandler(IMapper mapper, ProductProto.ProductProtoClient productProto, PriceProto.PriceProtoClient priceProto)
        {
            _mapper = mapper;
            this.productProto = productProto;
            this.priceProto = priceProto;
        }

        public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var productId = new ProductIdRequest()
            {
                ProductId = request.pid.ToString(),
                Tracking = false
            };

            var product = await productProto.GetProductByIdAsync(productId);
            var price = await priceProto.GetCurrentPriceAsync(_mapper.Map<SingleProductIdRequest>(productId));

            var productDTO = _mapper.Map<ProductResponse, ProductDTO>(product);
            productDTO = _mapper.Map(price, productDTO);

            return productDTO;
        }
    }
}
