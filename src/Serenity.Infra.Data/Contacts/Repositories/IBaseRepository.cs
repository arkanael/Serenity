using System;
using System.Collections.Generic;

namespace Serenity.Infra.Data.Contacts.Repositories
{
    public interface IBaseRepository<TEntity, TKey> : IDisposable where TEntity : class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Remove(TKey key);
        List<TEntity> GetAll();
        TEntity Get(TKey key);
    }
}
