using System.Net;

namespace Aquapets.Shared.Api.Exceptions
{
    public class RegisterUserException : ApiException
    {
        public RegisterUserException(string message) : base(message)
        {
            StatusCode = (int)HttpStatusCode.BadRequest;
        }
        
    }
}
