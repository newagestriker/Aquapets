
namespace Aquapets.Shared.Abstractions.Exceptions
{
    public class UnknownErrorException : AquapetsException
    {
        public UnknownErrorException() : base("An unknown server error occurred")
        {
        }
    }
}
