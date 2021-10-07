using AutoMapper;
using Instagram.HttpMessages.Dtos;
using Instagram.Services.IServices;
using Instagram.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Instagram.Services
{
    public class PostImageService : IPostImageService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public PostImageService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PostImageDto>> GetByPostId(Guid postId)
        {
            var entities = await unitOfWork.IPostImageRepository.GetByPostId(postId);
            return mapper.Map<IEnumerable<PostImageDto>>(entities);
        }
    }
}
