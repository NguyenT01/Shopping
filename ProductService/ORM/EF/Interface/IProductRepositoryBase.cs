using System.Linq.Expressions;

namespace ProductServiceNamespace.ORM.EF.Interface
{
    public interface IProductRepositoryBase<T>
    {
        void Add(T entity);
        void Delete(T entity);
        IQueryable<T> FindAll(bool tracking);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool tracking);
    }
}
