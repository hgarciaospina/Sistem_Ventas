using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistem_Ventas.Library
{
    public class Usuarios : ListObject
    {
        public Usuarios() {

        }


        public Usuarios(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _usersRole = new UsersRoles();
        }

        public Usuarios(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser>  signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _usersRole = new UsersRoles();
        }

        internal async Task<List<object[]>> userLogin(string email, string password)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(email, password, false,
                    //En false no bloquea la cuenta si no se autentica correctamente
                    lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    //Buscamos en la BD el usuario logueado y cargamos sus datos en appUser
                    var appUser = _userManager.Users.Where(u => u.Email.Equals(email)).ToList();
                }
                else
                {
                    code = "1";
                    description = "Correo o contraseña inválidos";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
