using Instagram.Helpers;
using Instagram.Helpers.SortHelpers;
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
        private readonly ISortHelper sortHelper;

        public PostRepository(InstagramDBContext context, ISortHelper sortHelper) : base(context)
        {
            this.context = context;
            this.sortHelper = sortHelper;
        }

        public async override Task<Post> GetById(Guid id)
        {
            return await context.Posts.Include(c => c.PostImages)
                .Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<PagedList<Post>> QueryPost(GetHomePostRequest request)
        {
            var entities = context.Posts.Include(s => s.PostImages).Include( s => s.Owner).AsQueryable();
            entities = entities.OrderByDescending(e => e.ModifiedAt);
            sortHelper.ApplySort<Post>(ref entities, request.SortBy, request.OrderBy);
            return PagedList<Post>.ToPagedList(entities, request.PageNumber, request.PageSize);
        }
    }
}
