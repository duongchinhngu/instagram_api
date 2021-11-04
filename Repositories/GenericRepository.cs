using Instagram.Models;
using Instagram.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Instagram.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly InstagramDBContext context;
        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(InstagramDBContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual async Task AddAndSave(TEntity entity)
        {
            dbSet.Add(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateAndSave(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
