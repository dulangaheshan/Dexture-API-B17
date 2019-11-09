using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dexture.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);

        IEnumerable<TEntity> Getselected(long id);
        TEntity Get(String email);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
        long AddData(TEntity entity);
    }
}
