using AutoMapper;
using MediatR;

namespace Shopping.API.v2.Application.Commands.Price
{
    public record DeletePriceCommand : IRequest<Unit>
    {
        public Guid priceId;
    }

    public class DeletePriceHandler : IRequestHandler<DeletePriceCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly PriceProto.PriceProtoClient priceProto;

        public DeletePriceHandler(IMapper mapper, PriceProto.PriceProtoClient priceProto)
        {
            _mapper = mapper;
            this.priceProto = priceProto;
        }

        public async Task<Unit> Handle(DeletePriceCommand request, CancellationToken cancellationToken)
        {
            var priceIdRequest = new PriceIdRequest()
            {
                PriceId = request.priceId.ToString()
            };

            await priceProto.DeletePriceAsync(priceIdRequest);
            return Unit.Value;
        }
    }

}
