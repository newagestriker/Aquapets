﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquapets.Shared.Application.DTOs
{
    public class LoginDto
    {
        [Required, Display(Name = "Email"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, Display(Name = "Password"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
