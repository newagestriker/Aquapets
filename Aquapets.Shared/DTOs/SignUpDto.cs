using System.ComponentModel.DataAnnotations;


namespace Aquapets.Shared.Application.DTOs
{
    public class SignUpDto
    {

        [Required, Display(Name = "Email"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, Display(Name = "Password"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
