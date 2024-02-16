using Microsoft.EntityFrameworkCore;
using ProductServiceNamespace.ORM.EF.Interface;
using ProductServiceNamespace.ORM.EF.Model;

namespace ProductServiceNamespace.ORM.EF
{
    public class PriceRepository : ProductRepositoryBase<Price>, IPriceRepository
    {
        public PriceRepository(ProductContext context) : base(context) { }

        public void CreatePrice(Price price)
            => Add(price);

        public void DeletePrice(Price price)
            => Delete(price);

        public void DeletePriceByProductId(IEnumerable<Price> prices)
            => DeleteRange(prices);

        public async Task<IEnumerable<Price>> GetPriceByRangeTime(Guid productId, bool tracking, DateTime startDate,
                    DateTime endDate)
            => await FindByCondition(price => price.ProductId.Equals(productId) && (startDate <= price.StartDate
                                || endDate >= price.EndDate), tracking)
                            .OrderBy(price => price.StartDate)
                            .ThenBy(price => price.EndDate)
                            .ToListAsync();

        public async Task<Price?> GetPrice(Guid priceId, bool tracking)
            => await FindByCondition(price => price.PriceId.Equals(priceId), tracking)
                        .SingleOrDefaultAsync();

        public async Task<IEnumerable<Price>> GetPrices(Guid productId, bool tracking)
            => await FindByCondition(price => price.ProductId.Equals(productId), tracking)
                        .OrderBy(price => price.StartDate)
                        .ThenBy(price => price.EndDate)
                        .ToListAsync();

        public async Task<Price?> GetCurrentPrice(Guid productId, bool tracking)
        {
            var currentDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

            return await FindByCondition(price => price.ProductId.Equals(productId) && (currentDate >= price.StartDate
                                && currentDate <= price.EndDate), tracking)
                .OrderBy(price => price.EndDate)
                .ThenByDescending(price => price.StartDate)
                .FirstOrDefaultAsync();
        }
    }
}
