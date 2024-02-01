using System.Linq.Expressions;

namespace OrderingService.ORM.EF.Interface
{
    public interface IOrderingRepositoryBase<T>
    {
        void Add(T entity);
        void Delete(T entity);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool tracking);
        IQueryable<T> FindAll(bool tracking);
    }
}
