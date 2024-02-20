using AutoMapper;
using MediatR;
using Shopping.API.Dto;
using Shopping.API.Protos.Manager;

namespace Shopping.API.v2.Application.Commands.Price
{
    public class UpdatePriceCommand : IRequest<Unit>
    {
        public PriceUpdateDTO? priceDTO;
    }

    public class UpdatePriceHandler : IRequestHandler<UpdatePriceCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public UpdatePriceHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<Unit> Handle(UpdatePriceCommand request, CancellationToken cancellationToken)
        {
            var price = _mapper.Map<PriceUpdateRequest>(request.priceDTO);
            await Protos.Price.UpdatePriceAsync(price);
            return Unit.Value;
        }
    }

}
