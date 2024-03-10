using ProductServiceNamespace.ORM.EF.Model;

namespace ProductServiceNamespace.ORM.Dapper
{
    public interface IPriceDapper
    {
        Task<Price?> GetPrice(Guid priceId);
        Task<IEnumerable<Price>> GetPrices(Guid productId);
        Task<IEnumerable<Price>> GetPriceByRangeTime(Guid productId, DateTime startDate, DateTime endDate);
        Task<Price?> GetCurrentPrice(Guid productId);
    }
}
