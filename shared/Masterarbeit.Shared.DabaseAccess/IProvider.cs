using System.Collections.Generic;

namespace Masterarbeit.Shared.DabaseAccess
{
    public interface IProvider<TEntity>
    {
        TEntity Get(int id);
        IEnumerable<TEntity> Get();
        TEntity Create(TEntity entity);
        IEnumerable<TEntity> Create(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        IEnumerable<TEntity> Update(IEnumerable<TEntity> entities);
        void Delete(int id);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
        void Delete(IEnumerable<int> ids);
    }
}
