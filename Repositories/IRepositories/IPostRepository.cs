using Instagram.Helpers;
using Instagram.HttpMessages.Requests;
using Instagram.Models;
using System.Threading.Tasks;

namespace Instagram.Repositories.IRepositories
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<PagedList<Post>> QueryPost(GetHomePostRequest request);
    }
}
