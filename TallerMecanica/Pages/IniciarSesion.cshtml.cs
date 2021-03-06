using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using CapaDatos;
using CapaModelos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Session;
using TallerMecanica.Dto;

namespace TallerMecanica.Pages
{
    [AllowAnonymous]
    public class IniciarSesionModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IniciarSesionModel(ApplicationDbContext db)
        {
            _db = db;
        } 

        [BindProperty]
        public LoginModel loginModel { get; set; }
        public List<EmpleadoM> empleadoMs { get; set; }
        public void OnGet()
        {

        }
        public ActionResult Onpost(string returnUrl)
        {
            #region usuario Login por Base de datos
            var usuario = GetEmpleadoM(loginModel.Usuario, loginModel.Password);
            if (usuario != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim ("id", usuario.ID.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim(ClaimTypes.Role, usuario.Roles)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                     principal,
                     new AuthenticationProperties
                     {
                         IsPersistent = loginModel.Recordarme

                     }).GetAwaiter().GetResult();

                returnUrl = returnUrl == null || returnUrl == "/" ? "Index" : returnUrl;
                return RedirectToPage(returnUrl);
            }
            #endregion



            #region Usuario administrador por defecto
            /// Usuario administrador por defecto
            IserviceLogin iservice = new IserviceLogin();
                var aux = iservice.GetUsuario(loginModel.Usuario, loginModel.Password);
                if (aux != null)
                {
                    var claims = new List<Claim>()
                {
                new Claim ("id", aux.ID.ToString()),
                new Claim (ClaimTypes.Name, aux.Nombre),
                new Claim (ClaimTypes.Role, aux.Roles)
                };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        principal,
                        new AuthenticationProperties
                        {
                            IsPersistent = loginModel.Recordarme
                        }
                        ).GetAwaiter().GetResult();
                    returnUrl = returnUrl == null || returnUrl == "/" ? "Index" : returnUrl;
                    return RedirectToPage(returnUrl);
                }
                #endregion

            return Page();
        }

        public EmpleadoM GetEmpleadoM(string login, string password)
        {
            empleadoMs = _db.empleado.ToList();
            return empleadoMs.FirstOrDefault(u => u.Correo == login && u.Contrasena == password);
        }

    }
}
