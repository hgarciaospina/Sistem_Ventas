using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sistem_Ventas.Areas.Usuarios.Models;
using Sistem_Ventas.Library;

namespace Sistem_Ventas.Areas.Usuarios.Pages.Registrar
{
    public class RegistrarModel : PageModel
    {
        private LUsuarios _usuarios;
        public void OnGet()
        {
            _usuarios = new LUsuarios();
            ViewData["Roles"] = _usuarios.userData(HttpContext);
        }
  
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel : InputModelRegistrar
        {

        }
 
    }
}