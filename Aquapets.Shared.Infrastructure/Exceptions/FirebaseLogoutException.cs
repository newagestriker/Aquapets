using Aquapets.Shared.Application.Exceptions;

namespace Aquapets.Shared.Infrastructure.Exceptions
{
    internal class FirebaseLogoutException : ServiceException
    {
        public FirebaseLogoutException(string message) : base(message, "Logout")
        {
        }
    }
}
