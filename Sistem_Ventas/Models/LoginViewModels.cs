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
            [Required(ErrorMessage ="<font color='red'>Debe de ingresar un correo electrónico...</ font>")]
            [EmailAddress(ErrorMessage = "<font color='red'>Debe de ingresar un correo electrónico válido</ font>")]
            public String Email { get; set; }

            [Required(ErrorMessage = "<font color='red'>Debe de ingresar una contraseña...</ font>")]
            [DataType(DataType.Password)]
            [StringLength(100, ErrorMessage = "<font color='red'>El número de caracteres del {0} debe ser de al menos {2}...</ font>", MinimumLength = 6)]
            public String Password { get; set; }


            }
    }
}
