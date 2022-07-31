using Aquapets.Domain.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquapets.Domain.ValueObjects
{
    public record UserRole
    {
        public UserRole(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");
            }
            if(!Enum.TryParse<Consts.UserRole>(value, true, out role))
            {
                throw new ArgumentOutOfRangeException("Role not found");
            }
            
        }

        public Consts.UserRole role;

        public static implicit operator string(UserRole userRole) => userRole.ToString();

        public static implicit operator UserRole(string value) => new(value);

        public override string ToString()
        {
            return role.ToString();
        }




    }
}
