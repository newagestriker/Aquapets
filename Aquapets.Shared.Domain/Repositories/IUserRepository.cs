using Aquapets.Shared.Domain.Entities;

namespace Aquapets.Shared.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        User UpdateUser(User user);
        void DeleteUser(User user);
        User GetUser(User user);

    }
}
