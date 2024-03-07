using AutoMapper;
using MediatR;
using Shopping.API.Dto;

namespace Shopping.API.v2.Application.Queries.Price
{
    public class GetPriceQuery : IRequest<PriceDTO>
    {
        public Guid priceId;
    }

    public class GetPriceHandler : IRequestHandler<GetPriceQuery, PriceDTO>
    {
        private readonly IMapper _mapper;
        private readonly PriceProto.PriceProtoClient priceProto;

        public GetPriceHandler(IMapper mapper, PriceProto.PriceProtoClient priceProto)
        {
            _mapper = mapper;
            this.priceProto = priceProto;
        }

        public async Task<PriceDTO> Handle(GetPriceQuery request, CancellationToken cancellationToken)
        {
            var priceIdRequest = new PriceIdRequest()
            {
                PriceId = request.priceId.ToString()
            };
            var price = await priceProto.GetPriceAsync(priceIdRequest);
            var priceDTO = _mapper.Map<PriceDTO>(price);
            return priceDTO;
        }
    }
}
