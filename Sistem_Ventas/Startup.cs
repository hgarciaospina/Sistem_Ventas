﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistem_Ventas.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sistem_Ventas
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                // context => false --> deshabilita el banner y los botones por defecto que muestra al iniciar la aplicación
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.ConfigureApplicationCookie(options => {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                /* Cuando no tiene autorización se direcciona a la acción 
                   Index del controller Home que corresponde al Login
                */
                options.LoginPath = "/Home/Index";
            });

            services.AddSession(options => {
                options.Cookie.Name = ".SystemVentas.Session";
                options.IdleTimeout = TimeSpan.FromHours(12);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            /*  Método recomendado para desplegar errores en una página personalizada
             *  recibe 3 parámetros
                ("/controlador/accion_controlador", "?statusCode={0}");
             */

            app.UseStatusCodePagesWithReExecute("/Error/Error", "?statusCode={0}");

            /* Código de error por default si se ingresa una url no válida
             
               app.UseStatusCodePages(); 
            */

            /* Otra forma de ver el Código de error por default si se ingresa una url no válida
             * despliega el error en la vista personalizada Error.
             
               app.UseStatusCodePagesWithRedirects("/Error");
             */


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                //Ruta por defecto de la página que muestra de primero
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                /*
                 * routes.MapAreaRoute --> Indica que el controlador se encuentra en un Area
                 * ("Principal") --> Nombre que tiene la ruta, en este caso se llama Principal
                 * ("Principal") --> El siguiente parámetro es el nombre del Area, en este caso Principal
                 * Template de la ruta :  "{controller=Principal}/{action=Index}/{id?}"
                 * el valor para controller es el nombre del controlador que para este caso es Principal
                 */

            routes.MapAreaRoute("Principal", "Principal", "{controller=Principal}/{action=Index}/{id?}");

            routes.MapAreaRoute("Usuarios", "Usuarios", "{controller=Usuarios}/{action=Index}/{id?}");
                
            });
        }
    }
}
