using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquapets.Shared.Infrastructure.Exceptions
{
    internal class FirebaseLogoutException : ServiceException
    {
        public FirebaseLogoutException(string message) : base(message, "Logout")
        {
        }
    }
}
