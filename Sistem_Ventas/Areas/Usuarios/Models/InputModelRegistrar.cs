using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistem_Ventas.Areas.Usuarios.Models
{
    public class InputModelRegistrar
    {
        [Required(ErrorMessage = "<font color='red'>El campo nombre es obligatorio </font>")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "<font color='red'>El campo apellido es obligatorio </font>")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "<font color='red'>El campo NID es obligatorio </font>")]
        public string NID { get; set; }

        [Required(ErrorMessage = "<font color='red'>El campo ´teléfono es obligatorio </font>")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "<font color='red'>El campo correo electrónico es obligatorio </font>")]
        [EmailAddress(ErrorMessage = "<font color='red'>El correo electrónico no tiene un formato válido </font>")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "<font color='red'>El campo contraseña es obligatorio </font>")]
        [StringLength(100, ErrorMessage = "<font color='red'>El número de carácteres de {0} debe ser al menos {1}  carácteres</font>", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
