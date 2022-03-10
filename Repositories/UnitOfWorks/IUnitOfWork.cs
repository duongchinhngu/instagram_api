using Instagram.Repositories;
using Instagram.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instagram.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        public IPostRepository IPostRepository { get; }
        public IPostImageRepository IPostImageRepository { get; }
        public IUserRepository IUserRepository { get; }
        Task Commit();
        Task RollBack();
    }
}
