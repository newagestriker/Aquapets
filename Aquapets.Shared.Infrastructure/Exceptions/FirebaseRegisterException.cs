using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquapets.Shared.Infrastructure.Exceptions
{
    public class FirebaseRegisterException : ServiceException
    {
        public FirebaseRegisterException(string message) : base(message, "Register")
        {
        }
    }
}
