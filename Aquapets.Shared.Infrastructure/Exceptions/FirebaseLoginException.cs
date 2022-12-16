using Aquapets.Shared.Application.Exceptions;

namespace Aquapets.Shared.Infrastructure.Exceptions
{
    public class FirebaseLoginException : ServiceException
    {
        public FirebaseLoginException(string message) : base(message, "Login")
        {
        }
    }
}
