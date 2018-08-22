using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sistem_Ventas.Controllers
{
    /* Este atributo se debe comentariar para implementar el otro método de error
       [Route("/Error")]
    */
    public class ErrorController : Controller
    {
        /* Recibe los datos por Get sino se le específica el tipo de petición
          int? --> el signo de interrogación quiere decir que puede llegar null o recibir un entero
         */ 
         
        public IActionResult Error(int? statusCode = null)
        {
            /* Si devuelve un entero */
            if (statusCode.HasValue)
            {
                if (statusCode.Value == 404 || statusCode.Value == 500)
                {
                    /* ViewData Puede almacenar datos por el lado del servidor 
                       y se puede obtener esta  información desde nuestras vistas razor (lado del cliente)
                       y se convierte statusCode a cadena para poder pasarla a la vista
                    */
                    ViewData["Error"] = statusCode.ToString();
                }
            }
            return View();
        }
    }
}