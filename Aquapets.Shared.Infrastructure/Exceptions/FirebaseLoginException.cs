using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquapets.Shared.Infrastructure.Exceptions
{
    public class FirebaseLoginException : ServiceException
    {
        public FirebaseLoginException(string message) : base(message, "Login")
        {
        }
    }
}
