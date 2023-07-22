using System.Linq.Expressions;
using Service1.Repositories.Contracts;

namespace Service1.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly List<T>? _store;

    public RepositoryBase(RepositoryContext repositoryContext)
    {
        _store = repositoryContext.Set<T>();
    }

    public void Create(T entity)
    {
        _store?.Add(entity);
    }

    public void Delete(T entity)
    {
        _store?.Remove(entity);
    }

    public IEnumerable<T>? FindAll()
    {
        return _store;
    }

    public IEnumerable<T>? FindByCondition(Expression<Func<T, bool>> expression)
    {
        return _store?.Where(expression.Compile());
    }

    public void Update(T entity)
    {
        var updatedObj = entity as dynamic;
        var currentObj = _store?.Find(o => (o as dynamic).Id == updatedObj.Id);
        
        if (currentObj != null)
        {
            Delete(currentObj);
            Create(updatedObj);
        };
    }
}