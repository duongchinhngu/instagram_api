using Instagram.HttpMessages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instagram.Services.IServices
{
    public interface IUserService
    {
        Task<UserDto> GetById(Guid id);
    }
}
