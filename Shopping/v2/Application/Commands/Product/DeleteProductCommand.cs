using AutoMapper;
using MediatR;

namespace Shopping.API.v2.Application.Commands.Product
{
    public record DeleteProductCommand : IRequest<Unit>
    {
        public Guid pid;
    }

    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ProductProto.ProductProtoClient productProto;
        private readonly PriceProto.PriceProtoClient priceProto;

        public DeleteProductHandler(IMapper mapper, ProductProto.ProductProtoClient productProto, PriceProto.PriceProtoClient priceProto)
        {
            _mapper = mapper;
            this.productProto = productProto;
            this.priceProto = priceProto;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productIDRequest = new SingleProductIdRequest()
            {
                ProductId = request.pid.ToString()
            };

            await priceProto.DeletePriceByProductIdAsync(productIDRequest);

            var productIdRequest2 = _mapper.Map<DeleteProductRequest>(productIDRequest);

            await productProto.DeleteProductAsync(productIdRequest2);

            return Unit.Value;
        }
    }

}
