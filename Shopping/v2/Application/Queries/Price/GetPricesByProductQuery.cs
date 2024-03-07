using AutoMapper;
using MediatR;
using Shopping.API.Dto;

namespace Shopping.API.v2.Application.Queries.Price
{
    public class GetPricesByProductQuery : IRequest<IEnumerable<PriceDTO>>
    {
        public Guid productId;
    }

    public class GetPricesByProductHandler : IRequestHandler<GetPricesByProductQuery, IEnumerable<PriceDTO>>
    {
        private readonly IMapper _mapper;
        private readonly PriceProto.PriceProtoClient priceProto;

        public GetPricesByProductHandler(IMapper mapper, PriceProto.PriceProtoClient priceProto)
        {
            _mapper = mapper;
            this.priceProto = priceProto;
        }

        public async Task<IEnumerable<PriceDTO>> Handle(GetPricesByProductQuery request, CancellationToken cancellationToken)
        {
            var productIdRequest = new SingleProductIdRequest()
            {
                ProductId = request.productId.ToString()
            };

            var priceListResponse = await priceProto.GetHistoryPriceListOfProductAsync(productIdRequest);
            var priceList = _mapper.Map<IEnumerable<PriceDTO>>(priceListResponse.PriceList);
            return priceList;
        }
    }
}
