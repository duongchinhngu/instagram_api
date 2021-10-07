using Instagram.Helpers.SortHelpers;
using Instagram.Models;
using Instagram.Repositories;
using Instagram.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instagram.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InstagramDBContext context;
        private readonly ISortHelper sortHelper;
        private bool disposedValue;

        public UnitOfWork(InstagramDBContext context, ISortHelper sortHelper)
        {
            this.context = context;
            this.sortHelper = sortHelper;
            InitRepositories();
        }

        public IPostRepository IPostRepository { get; private set; }
        public IPostImageRepository IPostImageRepository { get; private set; }

        private void InitRepositories()
        {
            IPostRepository = new PostRepository(context, sortHelper);
            IPostImageRepository = new PostImageRepository(context);
        }

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }

        public async Task RollBack()
        {
            await context.DisposeAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
