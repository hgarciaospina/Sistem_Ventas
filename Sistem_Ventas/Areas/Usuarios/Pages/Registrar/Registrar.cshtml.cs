using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sistem_Ventas.Areas.Usuarios.Models;
using Sistem_Ventas.Library;

namespace Sistem_Ventas.Areas.Usuarios.Pages.Registrar
{
    public class RegistrarModel : PageModel
    {
        private ListObject listObject = new ListObject();

        public RegistrarModel(RoleManager<IdentityRole> roleManager)
        {
            listObject._roleManager = roleManager;
            listObject._usuarios = new LUsuarios();
            listObject._usersRole = new UsersRoles();
        }
        public void OnGet()
        {
            Input = new InputModel
            {
                rolesLista = listObject._usersRole.getRoles(listObject._roleManager)
            };
    
        }
  
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel : InputModelRegistrar
        {
            [Required]
            public string Role { get; set; }
            public List<SelectListItem> rolesLista { get; set; }
        }
 
    }
}