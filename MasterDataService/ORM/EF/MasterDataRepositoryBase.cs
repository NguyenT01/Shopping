using MasterDataService.ORM.EF.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MasterDataService.ORM.EF;

public class MasterDataRepositoryBase<T> : IMasterDataRepositoryBase<T> where T : class
{
    protected readonly MasterDataRepositoryContext MasterDataRepositoryContext;
    public MasterDataRepositoryBase(MasterDataRepositoryContext MasterDataRepositoryContext)
    {
        this.MasterDataRepositoryContext = MasterDataRepositoryContext;
    }

    public void Add(T entity)
        => MasterDataRepositoryContext.Set<T>().Add(entity);

    public void Delete(T entity)
        => MasterDataRepositoryContext.Set<T>().Remove(entity);

    public IQueryable<T> FindAll(bool tracking)
    {
        if (tracking)
            return MasterDataRepositoryContext.Set<T>();
        return MasterDataRepositoryContext.Set<T>().AsNoTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool tracking)
    {
        if (tracking)
            return MasterDataRepositoryContext.Set<T>().Where(condition);
        return MasterDataRepositoryContext.Set<T>().Where(condition).AsNoTracking();
    }

    public void Update(T entity)
        => MasterDataRepositoryContext.Set<T>().Update(entity);
}
