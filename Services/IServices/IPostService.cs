using Instagram.HttpMessages.Dtos;
using Instagram.HttpMessages.Requests;
using Instagram.HttpMessages.Responses;
using System;
using System.Threading.Tasks;

namespace Instagram.Services.IServices
{
    public interface IPostService
    {
        Task<PostDto> GetByID(Guid id);
        Task<PagingResponse<PostDto>> QueryPost(GetHomePostRequest request);
        Task<CreatePostResponse> CreateNewPost(CreateNewPostRequest create);
    }
}
