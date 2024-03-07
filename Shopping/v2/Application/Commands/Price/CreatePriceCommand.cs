using AutoMapper;
using MediatR;
using Shopping.API.Dto;

namespace Shopping.API.v2.Application.Commands.Price
{
    public class CreatePriceCommand : IRequest<PriceDTO>
    {
        public PriceCreationDTO? priceCreationDTO;
    }

    public class CreatePriceHandler : IRequestHandler<CreatePriceCommand, PriceDTO>
    {
        private readonly IMapper _mapper;
        private readonly PriceProto.PriceProtoClient priceProto;

        public CreatePriceHandler(IMapper mapper, PriceProto.PriceProtoClient priceProto)
        {
            _mapper = mapper;
            this.priceProto = priceProto;
        }

        public async Task<PriceDTO> Handle(CreatePriceCommand request, CancellationToken cancellationToken)
        {
            var priceRequest = _mapper.Map<PriceCreationRequest>(request.priceCreationDTO);
            var price = await priceProto.CreateNewPriceAsync(priceRequest);
            var priceDTO = _mapper.Map<PriceDTO>(price);
            return priceDTO;
        }
    }
}
