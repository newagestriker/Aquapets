using Aquapets.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquapets.Shared.Infrastructure.Exceptions
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
