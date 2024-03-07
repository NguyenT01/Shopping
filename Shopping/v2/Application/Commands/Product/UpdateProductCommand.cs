using AutoMapper;
using MediatR;
using Shopping.API.Dto;

namespace Shopping.API.v2.Application.Commands.Product
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public ProductUpdateDTO? productDTO;
    }

    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ProductProto.ProductProtoClient productProto;
        private readonly PriceProto.PriceProtoClient priceProto;

        public UpdateProductHandler(IMapper mapper, ProductProto.ProductProtoClient productProto, PriceProto.PriceProtoClient priceProto)
        {
            _mapper = mapper;
            this.productProto = productProto;
            this.priceProto = priceProto;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<UpdateProductRequest>(request.productDTO);
            await productProto.UpdateProductAsync(product);

            var productIdRequest = _mapper.Map<SingleProductIdRequest>(request.productDTO);
            var currentPrice = await priceProto.GetCurrentPriceAsync(productIdRequest);

            var priceUpdate = _mapper.Map<PriceUpdateRequest>(currentPrice);
            priceUpdate = _mapper.Map(request.productDTO, priceUpdate);
            await priceProto.UpdatePriceAsync(priceUpdate);

            return Unit.Value;
        }
    }
}
