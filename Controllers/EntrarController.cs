using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectAvanzada.Claasses;
using System.Web.Security;

namespace ProyectAvanzada.Controllers
{
    public class EntrarController : Controller
    {
        // GET: Entrar
        public ActionResult Login()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Login(Login login, string url)
        {
            if (IsValido(login))
            {
                FormsAuthentication.SetAuthCookie(login.EMAIL, false);

                if (url != null)
                {
                    return Redirect(url);
                }
                return RedirectToAction("Index", "Home");
            }
            TempData["Mensaje"] = "Credenciales Incorrectas.";
            return View(login);
        }

        public bool IsValido(Login login)
        {
            return login.Autenticacion();
        }

        public ActionResult Logut(Login login, string url)
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }






    }
}