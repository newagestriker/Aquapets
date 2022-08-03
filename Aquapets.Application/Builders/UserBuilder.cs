using Aquapets.Domain.Consts;
using Aquapets.Domain.Entity;

namespace Aquapets.Application.Builder
{
    public class UserBuilder
    {
        User _user;
        public UserBuilder(string username, string password)
        {
            _user = new(username, password);
        }

        public User setFirstName(string firstName)
        {
            _user.FirstName = firstName;
            return _user;
        }
        public User setLastname(string lastName)
        {
            _user.LastName = lastName;
            return _user;
        }
        public User setRole(string userRole)
        {
            _user.Role = userRole;
            return _user;
        }
    }
}
