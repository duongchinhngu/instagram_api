using Instagram.Models;
using Instagram.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instagram.Repositories
{
    public class PostImageRepository : GenericRepository<PostImage>, IPostImageRepository
    {
        private readonly InstagramDBContext context;
        public PostImageRepository(InstagramDBContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PostImage>> GetByPostId(Guid postId)
        {
            return await context.PostImages.Where(i => i.PostId.Equals(postId)).ToListAsync();
        }
    }
}
