using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sistem_Ventas.Library;
using Sistem_Ventas.Models;

namespace Sistem_Ventas.Controllers
{
    public class HomeController : Controller
    {
        private Usuarios _usuarios;

        public HomeController(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _usuarios = new Usuarios(userManager, signInManager, roleManager);
        }
        public IActionResult Index()
        {
            return View();
        }

        //Envia el objeto model a la vista index con los datos del Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(LoginViewModels model)
        {
            //Valida de que las propiedades de LoginViewModels traigan sus datos correspondientes
            if (ModelState.IsValid)
            {
                List<object[]> listObject = await _usuarios.userLogin(model.Input.Email, 
                    model.Input.Password);
            }
            return View(model);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            String[] rolesName = { "Admin", "User" };
            foreach (var item in rolesName)
            {
                var roleExist = await roleManager.RoleExistsAsync(item);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(item));
                }
            }
            var user = await userManager.FindByIdAsync("c400982d-834e-4c03-a0a4-94795f98ece1");
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }

}
