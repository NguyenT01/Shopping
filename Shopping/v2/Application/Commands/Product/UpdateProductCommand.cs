using AutoMapper;
using MediatR;
using Shopping.API.Dto;
using Shopping.API.Protos.Manager;

namespace Shopping.API.v2.Application.Commands.Product
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public ProductUpdateDTO? productDTO;
    }

    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public UpdateProductHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<UpdateProductRequest>(request.productDTO);
            await Protos.Product.UpdateProductAsync(product);

            var productIdRequest = _mapper.Map<SingleProductIdRequest>(request.productDTO);
            var currentPrice = await Protos.Price.GetCurrentPriceAsync(productIdRequest);

            var priceUpdate = _mapper.Map<PriceUpdateRequest>(currentPrice);
            priceUpdate = _mapper.Map(request.productDTO, priceUpdate);
            await Protos.Price.UpdatePriceAsync(priceUpdate);

            return Unit.Value;
        }
    }
}
