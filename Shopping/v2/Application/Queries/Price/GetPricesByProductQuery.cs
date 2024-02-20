using AutoMapper;
using MediatR;
using Shopping.API.Dto;
using Shopping.API.Protos.Manager;

namespace Shopping.API.v2.Application.Queries.Price
{
    public class GetPricesByProductQuery : IRequest<IEnumerable<PriceDTO>>
    {
        public Guid productId;
    }

    public class GetPricesByProductHandler : IRequestHandler<GetPricesByProductQuery, IEnumerable<PriceDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public GetPricesByProductHandler(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<IEnumerable<PriceDTO>> Handle(GetPricesByProductQuery request, CancellationToken cancellationToken)
        {
            var productIdRequest = new SingleProductIdRequest()
            {
                ProductId = request.productId.ToString()
            };

            var priceListResponse = await Protos.Price.GetHistoryPriceListOfProductAsync(productIdRequest);
            var priceList = _mapper.Map<IEnumerable<PriceDTO>>(priceListResponse.PriceList);
            return priceList;
        }
    }
}
