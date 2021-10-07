using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instagram.Repositories.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(Guid id);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);

        Task Add(TEntity entity);
    }
}
