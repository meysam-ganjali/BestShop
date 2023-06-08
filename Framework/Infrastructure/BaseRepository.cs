using System.Linq.Expressions;
using Framework.IGenericRepository;
using Framework.SharedDomain;
using Microsoft.EntityFrameworkCore;

namespace Framework.Infrastructure;

public class BaseRepository<TKey,T> : IRepository<TKey,T> where T : BaseEntity
{
    private readonly DbContext _context;

    public BaseRepository(DbContext context)
    {
        _context = context;
    }
    public List<T> GetQuery()
    {
        return _context.Set<T>().ToList();
    }

    public T? Get(TKey id)
    {
        return _context.Find<T>(id);
    }

    public bool IsExist(Expression<Func<T, bool>> ex)
    {
        return _context.Set<T>().Any(ex);
    }

    public void Add(T entity)
    { 
        _context.Add(entity);
    }

    public void AddRange(List<T> entities)
    {
      _context.AddRange(entities);
    }

    public void Delete(TKey id)
    {
        var entity = Get(id);
        entity.IsRemove = true;
    }

    public void Restore(TKey id)
    {
        var entity = Get(id);
        entity.IsRemove = false;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}