using Instagram.Helpers;
using Instagram.HttpMessages.Requests;
using Instagram.Models;
using Instagram.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Instagram.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly InstagramDBContext context;

        public PostRepository(InstagramDBContext context) : base(context)
        {
            this.context = context;
        }

        public async override Task<Post> GetById(Guid id)
        {
            return await context.Posts.Include(c => c.PostImages)
                .Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<PagedList<Post>> QueryPost(GetHomePostRequest request)
        {
            var posts = context.Posts.Include(s => s.PostImages).AsQueryable();
            return PagedList<Post>.ToPagedList(posts, request.PageNumber, request.PageSize);
        }
    }
}
