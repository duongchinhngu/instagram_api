using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instagram.Repositories.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(Guid id);

        void Update(TEntity entity);
        Task UpdateAndSave(TEntity entity);

        Task Delete(TEntity entity);

        void Add(TEntity entity);
        Task AddAndSave(TEntity entity);

    }
}
