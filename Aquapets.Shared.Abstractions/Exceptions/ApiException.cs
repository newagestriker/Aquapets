namespace Aquapets.Shared.Abstractions.Exceptions
{
    public class ApiException : AquapetsException
    {
        public ApiException(string message) : base(message)
        {
        }
        public int StatusCode { get; set; }
    }
}
