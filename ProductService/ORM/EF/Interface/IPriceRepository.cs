using ProductServiceNamespace.ORM.EF.Model;

namespace ProductServiceNamespace.ORM.EF.Interface
{
    public interface IPriceRepository
    {
        Task<IEnumerable<Price>> GetPrices(Guid productId, bool tracking);
        Task<Price?> GetPrice(Guid priceId, bool tracking);
        Task<IEnumerable<Price>> GetPriceByRangeTime(Guid productId, bool tracking, DateTime startDate,
                    DateTime endDate);
        Task<Price?> GetCurrentPrice(Guid productId, bool tracking);
        void DeletePrice(Price price);
        void CreatePrice(Price price);
    }
}
