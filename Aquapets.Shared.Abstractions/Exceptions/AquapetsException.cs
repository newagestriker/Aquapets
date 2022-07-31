using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquapets.Shared.Abstractions.Exceptions
{
    public abstract class AquapetsException: Exception
    {
        protected AquapetsException(string message): base(message) { }
    }
}
