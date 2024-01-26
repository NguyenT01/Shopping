using System.Linq.Expressions;

namespace MasterDataService.ORM.EF.Interface;

public interface IMasterDataRepositoryBase<T>
{
    public IQueryable<T> FindAll(bool tracking);
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool tracking);
    public void Add(T entity);
    public void Update(T entity);
    public void Delete(T entity);
}
