using Aquapets.Shared.Application.Exceptions;

namespace Aquapets.Shared.Infrastructure.Exceptions
{
    public class FirebaseRegisterException : ServiceException
    {
        public FirebaseRegisterException(string message) : base(message, "Register")
        {
        }
    }
}
