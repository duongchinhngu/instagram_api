using Instagram.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Instagram.Repositories.IRepositories
{
    public interface IPostImageRepository : IGenericRepository<PostImage>
    {
        Task<IEnumerable<PostImage>> GetByPostId(Guid postId);
    }
}
