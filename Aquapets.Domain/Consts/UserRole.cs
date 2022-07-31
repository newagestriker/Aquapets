using System.ComponentModel;

namespace Aquapets.Domain.Consts
{
    public enum UserRole
    {
        [Description("Admin")]
        Admin,
        [Description("Default")]
        Default,
        [Description("Hobbyist")]
        Hobbyist,
        [Description("Seller")]
        Seller
    }
}
