using AutoMapper;
using Instagram.HttpMessages.Dtos;
using Instagram.Services.IServices;
using Instagram.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instagram.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<UserDto> GetById(Guid id)
        {
            var entity = await unitOfWork.IUserRepository.GetById(id);
            return mapper.Map<UserDto>(entity);

        }
    }
}
