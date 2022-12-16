using Aquapets.Shared.Abstractions.Exceptions;


namespace Aquapets.Shared.Application.Exceptions
{
    public abstract class ServiceException : AquapetsException
    {
        protected ServiceException(string message, string serviceType) : base($"{serviceType} : {message}")
        {
            ServiceType = serviceType;
        }

        public string ServiceType { get; set; }
    }
}
