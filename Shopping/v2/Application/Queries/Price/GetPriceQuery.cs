using AutoMapper;
using MediatR;
using Shopping.API.Dto;
using Shopping.API.Protos.Manager;

namespace Shopping.API.v2.Application.Queries.Price
{
    public class GetPriceQuery : IRequest<PriceDTO>
    {
        public Guid priceId;
    }

    public class GetPriceHandler : IRequestHandler<GetPriceQuery, PriceDTO>
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public GetPriceHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<PriceDTO> Handle(GetPriceQuery request, CancellationToken cancellationToken)
        {
            var priceIdRequest = new PriceIdRequest()
            {
                PriceId = request.priceId.ToString()
            };
            var price = await Protos.Price.GetPriceAsync(priceIdRequest);
            var priceDTO = _mapper.Map<PriceDTO>(price);
            return priceDTO;
        }
    }
}
