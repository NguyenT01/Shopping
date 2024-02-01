using Microsoft.EntityFrameworkCore;
using OrderingService.ORM.EF.Interface;
using System.Linq.Expressions;

namespace OrderingService.ORM.EF
{
    public class OrderingRepositoryBase<T> : IOrderingRepositoryBase<T> where T : class
    {
        protected readonly OrderingContext OrderingContext;

        public OrderingRepositoryBase(OrderingContext context)
        {
            OrderingContext = context;
        }

        public void Add(T entity)
            => OrderingContext.Set<T>().Add(entity);

        public void Delete(T entity)
            => OrderingContext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool tracking)
            => tracking ? OrderingContext.Set<T>() : OrderingContext.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool tracking)
            => tracking ? OrderingContext.Set<T>().Where(condition) : OrderingContext.Set<T>().Where(condition).AsNoTracking();
    }
}
