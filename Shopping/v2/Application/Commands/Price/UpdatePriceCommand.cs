using AutoMapper;
using MediatR;
using Shopping.API.Dto;

namespace Shopping.API.v2.Application.Commands.Price
{
    public class UpdatePriceCommand : IRequest<Unit>
    {
        public PriceUpdateDTO? priceDTO;
    }

    public class UpdatePriceHandler : IRequestHandler<UpdatePriceCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly PriceProto.PriceProtoClient priceProto;

        public UpdatePriceHandler(IMapper mapper, PriceProto.PriceProtoClient priceProto)
        {
            _mapper = mapper;
            this.priceProto = priceProto;
        }

        public async Task<Unit> Handle(UpdatePriceCommand request, CancellationToken cancellationToken)
        {
            var price = _mapper.Map<PriceUpdateRequest>(request.priceDTO);
            await priceProto.UpdatePriceAsync(price);
            return Unit.Value;
        }
    }

}
