using Framework.SharedDomain;
using System.Linq.Expressions;

namespace Framework.IGenericRepository;

public interface IRepository<TKey,T> where T: BaseEntity {
    List<T> GetQuery();
    T? Get(TKey id);
    bool IsExist(Expression<Func<T, bool>> ex);
    void Add(T entity);
    void AddRange(List<T> entities);
    void Delete(TKey id);
    void Restore(TKey id);
    void SaveChanges();
}