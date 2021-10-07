using Instagram.HttpMessages.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Instagram.Services.IServices
{
    public interface IPostImageService
    {
        Task<IEnumerable<PostImageDto>> GetByPostId(Guid postId);
    }
}
