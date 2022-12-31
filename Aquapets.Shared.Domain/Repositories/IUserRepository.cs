using Aquapets.Shared.Domain.Entities;

namespace Aquapets.Shared.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        void DeleteUser(User user);
        Task<User> GetUser(User user);

    }
}
