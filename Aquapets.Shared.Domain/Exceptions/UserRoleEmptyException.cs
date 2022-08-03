using Aquapets.Shared.Abstractions.Exceptions;

namespace Aquapets.Shared.Domain.Exceptions
{
    internal class UserRoleEmptyException : AquapetsException
    {
        public UserRoleEmptyException() : base("The User Role provided is empty.")
        {
        }
    }
}
