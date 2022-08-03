using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquapets.Shared.Infrastructure.Models
{
    internal class FirebaseErrorModel
    {
       public error error { get; set; }
        
        
    }
    public class error
    {

        public string message;
        public string code;
        public IEnumerable<errorModel> errors;
    }

    public class errorModel
    {
        public string message;
        public string domain;
        public string reason;

    }

}
