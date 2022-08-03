using Aquapets.Shared.Abstractions.Exceptions;

namespace Aquapets.Domain.Exceptions
{
    internal class UserRoleNotFoundException : AquapetsException
    {
        public UserRoleNotFoundException(string userRole) : base($"The User Role '{userRole}' does not exist")
        {
        }
    }
}
