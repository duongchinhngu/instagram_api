using Instagram.Models;
using Instagram.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instagram.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(InstagramDBContext context) : base(context)
        {
        }
    }
}
