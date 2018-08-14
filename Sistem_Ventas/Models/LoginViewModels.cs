using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistem_Ventas.Models
{
    public class LoginViewModels
    {
        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public String ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public String Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public String Password { get; set; }


            }
    }
}
