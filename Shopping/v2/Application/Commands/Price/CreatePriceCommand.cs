using AutoMapper;
using MediatR;
using Shopping.API.Dto;
using Shopping.API.Protos.Manager;

namespace Shopping.API.v2.Application.Commands.Price
{
    public class CreatePriceCommand : IRequest<PriceDTO>
    {
        public PriceCreationDTO? priceCreationDTO;
    }

    public class CreatePriceHandler : IRequestHandler<CreatePriceCommand, PriceDTO>
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public CreatePriceHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<PriceDTO> Handle(CreatePriceCommand request, CancellationToken cancellationToken)
        {
            var priceRequest = _mapper.Map<PriceCreationRequest>(request.priceCreationDTO);
            var price = await Protos.Price.CreateNewPriceAsync(priceRequest);
            var priceDTO = _mapper.Map<PriceDTO>(price);
            return priceDTO;
        }
    }
}
