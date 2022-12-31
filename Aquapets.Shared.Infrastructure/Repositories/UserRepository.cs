using Aquapets.Shared.Domain.Entities;
using Aquapets.Shared.Domain.Repositories;
using Aquapets.Shared.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;


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

        public async void DeleteUser(User user)
        {
            var userToDelete = await dbContext.Users!.SingleOrDefaultAsync(u => u.Id == user.Id);
            if(userToDelete != null) { return; }
            dbContext.Users!.Remove(userToDelete);
        }

        public Task<User> GetUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
