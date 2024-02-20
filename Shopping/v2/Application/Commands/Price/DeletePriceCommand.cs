using AutoMapper;
using MediatR;
using Shopping.API.Protos.Manager;

namespace Shopping.API.v2.Application.Commands.Price
{
    public record DeletePriceCommand : IRequest<Unit>
    {
        public Guid priceId;
    }

    public class DeletePriceHandler : IRequestHandler<DeletePriceCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public DeletePriceHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<Unit> Handle(DeletePriceCommand request, CancellationToken cancellationToken)
        {
            var priceIdRequest = new PriceIdRequest()
            {
                PriceId = request.priceId.ToString()
            };

            await Protos.Price.DeletePriceAsync(priceIdRequest);
            return Unit.Value;
        }
    }

}
