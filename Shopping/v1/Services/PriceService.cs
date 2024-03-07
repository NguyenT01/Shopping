using AutoMapper;
using Shopping.API.Dto;
using Shopping.API.v1.Services.Interfaces;

namespace Shopping.API.v1.Services
{
    public class PriceService : IPriceService
    {
        private readonly IMapper _mapper;
        private readonly PriceProto.PriceProtoClient priceProto;

        public PriceService(IMapper mapper, PriceProto.PriceProtoClient priceProto)
        {
            _mapper = mapper;
            this.priceProto = priceProto;
        }

        public async Task<PriceDTO> CreatePrice(PriceCreationDTO priceCreationDTO)
        {
            var priceRequest = _mapper.Map<PriceCreationRequest>(priceCreationDTO);
            var price = await priceProto.CreateNewPriceAsync(priceRequest);
            var priceDTO = _mapper.Map<PriceDTO>(price);
            return priceDTO;
        }

        public async Task DeletePrice(Guid priceId)
        {
            var priceIdRequest = new PriceIdRequest()
            {
                PriceId = priceId.ToString()
            };

            await priceProto.DeletePriceAsync(priceIdRequest);
        }

        public async Task<IEnumerable<PriceDTO>> GetAllPrices(Guid productId)
        {
            var productIdRequest = new SingleProductIdRequest()
            {
                ProductId = productId.ToString()
            };

            var priceListResponse = await priceProto.GetHistoryPriceListOfProductAsync(productIdRequest);
            var priceList = _mapper.Map<IEnumerable<PriceDTO>>(priceListResponse.PriceList);
            return priceList;
        }

        public async Task<PriceDTO> GetPrice(Guid priceId)
        {
            var priceIdRequest = new PriceIdRequest()
            {
                PriceId = priceId.ToString()
            };
            var price = await priceProto.GetPriceAsync(priceIdRequest);
            var priceDTO = _mapper.Map<PriceDTO>(price);
            return priceDTO;
        }

        public async Task UpdatePrice(PriceUpdateDTO priceDTO)
        {
            var price = _mapper.Map<PriceUpdateRequest>(priceDTO);
            await priceProto.UpdatePriceAsync(price);
        }
    }
}
