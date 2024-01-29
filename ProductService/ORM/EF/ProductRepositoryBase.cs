using Microsoft.EntityFrameworkCore;
using ProductService.ORM.EF.Interface;
using System.Linq.Expressions;

namespace ProductService.ORM.EF
{
    public class ProductRepositoryBase<T> : IProductRepositoryBase<T> where T : class
    {
        protected readonly ProductRepositoryContext ProductRepositoryContext;

        public ProductRepositoryBase(ProductRepositoryContext context)
        {
            ProductRepositoryContext = context;
        }


        public void Add(T entity)
            => Add(entity);

        public void Delete(T entity)
            => Delete(entity);

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
