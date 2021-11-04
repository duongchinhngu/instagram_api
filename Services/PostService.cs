using AutoMapper;
using Instagram.HttpMessages.Dtos;
using Instagram.HttpMessages.Requests;
using Instagram.HttpMessages.Responses;
using Instagram.Models;
using Instagram.Services.IServices;
using Instagram.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instagram.Services
{
    public class PostService : IPostService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public PostService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PostDto> GetByID(Guid id)
        {
            var entity = await unitOfWork.IPostRepository.GetById(id);
            return mapper.Map<PostDto>(entity);
        }

        public async Task CreateNewPost(CreateNewPostRequest createNewPostRequest)
        {
            var post = mapper.Map<Post>(createNewPostRequest);
            unitOfWork.IPostRepository.Add(post);
            foreach (var image in post.PostImages)
            {
                image.PostId = post.Id;
                unitOfWork.IPostImageRepository.Add(image);
            }
            await unitOfWork.Commit();
        }

        public async Task<PagingResponse<PostDto>> QueryPost(GetHomePostRequest request)
        {
            var response = await unitOfWork.IPostRepository.QueryPost(request);
            return mapper.Map<PagingResponse<PostDto>>(response);
        }
    }
}
