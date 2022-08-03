
using Aquapets.Shared.Domain.Exceptions;

namespace Aquapets.Shared.Domain.ValueObjects
{
    public record UserRole
    {
        public UserRole(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new UserRoleEmptyException();
            }
            if (!Enum.TryParse(value, true, out role))
            {
                throw new UserRoleNotFoundException(value);
            }

        }

        public Consts.UserRole role;

        public static implicit operator string(UserRole userRole) => userRole.ToString();

        public static implicit operator UserRole(string value) => new(value);

        public override string ToString()
        {
            return role.ToString();
        }




    }
}
