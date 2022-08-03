
namespace Aquapets.Shared.Abstractions.Exceptions
{
    public abstract class AquapetsException: Exception
    {
        protected AquapetsException(string message): base(message) { }
    }
}
