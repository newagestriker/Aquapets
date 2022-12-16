using Aquapets.Shared.Domain.Entities;
using Aquapets.Shared.Domain.Repositories;
using Aquapets.Shared.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquapets.Shared.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly UserDbContext dbContext;

        public UserRepository(UserDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task<User> AddUser(User user)
        {
            await dbContext.Users!.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUser(User user)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
