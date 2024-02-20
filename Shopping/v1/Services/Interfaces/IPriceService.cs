using Shopping.API.Dto;

namespace Shopping.API.v1.Services.Interfaces
{
    public interface IPriceService
    {
        Task<PriceDTO> GetPrice(Guid priceId);
        Task<IEnumerable<PriceDTO>> GetAllPrices(Guid productId);
        Task<PriceDTO> CreatePrice(PriceCreationDTO priceCreationDTO);
        Task DeletePrice(Guid priceId);
        Task UpdatePrice(PriceUpdateDTO priceDTO);
    }
}
