using Microsoft.EntityFrameworkCore;
using ProductServiceNamespace.ORM.EF.Interface;
using System.Linq.Expressions;

namespace ProductServiceNamespace.ORM.EF
{
    public class ProductRepositoryBase<T> : IProductRepositoryBase<T> where T : class
    {
        protected readonly ProductContext ProductRepositoryContext;

        public ProductRepositoryBase(ProductContext context)
        {
            ProductRepositoryContext = context;
        }

        public void Add(T entity)
             => ProductRepositoryContext.Set<T>().Add(entity);

        public void Delete(T entity)
            => ProductRepositoryContext.Set<T>().Remove(entity);

        public void DeleteRange(IEnumerable<T> entities)
            => ProductRepositoryContext.Set<T>().RemoveRange(entities);

        public IQueryable<T> FindAll(bool tracking)
        {
            if (tracking)
                return ProductRepositoryContext.Set<T>();
            return ProductRepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool tracking)
        {
            if (tracking)
                return ProductRepositoryContext.Set<T>().Where(condition);
            return ProductRepositoryContext.Set<T>().Where(condition).AsNoTracking();
        }
    }
}
