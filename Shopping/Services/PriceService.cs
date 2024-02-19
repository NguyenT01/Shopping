using AutoMapper;
using Shopping.API.Dto;
using Shopping.API.Protos.Manager;
using Shopping.API.Services.Interfaces;

namespace Shopping.API.Services
{
    public class PriceService : IPriceService
    {
        private readonly IMapper _mapper;
        private readonly IProtosManager Protos;

        public PriceService(IMapper mapper, IProtosManager protos)
        {
            _mapper = mapper;
            Protos = protos;
        }

        public async Task<PriceDTO> CreatePrice(PriceCreationDTO priceCreationDTO)
        {
            var priceRequest = _mapper.Map<PriceCreationRequest>(priceCreationDTO);
            var price = await Protos.Price.CreateNewPriceAsync(priceRequest);
            var priceDTO = _mapper.Map<PriceDTO>(price);
            return priceDTO;
        }

        public async Task DeletePrice(Guid priceId)
        {
            var priceIdRequest = new PriceIdRequest()
            {
                PriceId = priceId.ToString()
            };

            await Protos.Price.DeletePriceAsync(priceIdRequest);
        }

        public async Task<IEnumerable<PriceDTO>> GetAllPrices(Guid productId)
        {
            var productIdRequest = new SingleProductIdRequest()
            {
                ProductId = productId.ToString()
            };

            var priceListResponse = await Protos.Price.GetHistoryPriceListOfProductAsync(productIdRequest);
            var priceList = _mapper.Map<IEnumerable<PriceDTO>>(priceListResponse.PriceList);
            return priceList;
        }

        public async Task<PriceDTO> GetPrice(Guid priceId)
        {
            var priceIdRequest = new PriceIdRequest()
            {
                PriceId = priceId.ToString()
            };
            var price = await Protos.Price.GetPriceAsync(priceIdRequest);
            var priceDTO = _mapper.Map<PriceDTO>(price);
            return priceDTO;
        }

        public async Task UpdatePrice(PriceUpdateDTO priceDTO)
        {
            var price = _mapper.Map<PriceUpdateRequest>(priceDTO);
            await Protos.Price.UpdatePriceAsync(price);
        }
    }
}
