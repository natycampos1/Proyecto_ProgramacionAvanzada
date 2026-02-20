using KN_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KN_WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Horario()
        {
            ViewBag.Message = "Horario de buses.";
            return View();
        }

        public ActionResult Informacion()
        {
            ViewBag.Message = "Información general.";
            return View();
        }

        #region Iniciar Sesión

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            using (var context = new KN_DBEntities())
            {
                // Ahora usamos Identificacion porque eso es lo que envía la vista
                var result = context.IniciarSesion(modelo.Identificacion, modelo.Contrasenna)
                                    .FirstOrDefault();

                if (result == null)
                {
                    ViewBag.Mensaje = "Identificación o contraseña incorrectas.";
                    return View(modelo);
                }

                // Guardamos datos en sesión
                Session["IdUsuario"] = result.Identificacion;
                Session["Nombre"] = result.Nombre;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(UsuarioModel model)
        {
            using (var context = new KN_DBEntities())
            {
                var result = context.RegistrarUsuario(
                                model.Identificacion,
                                model.Contrasenna,
                                model.Nombre,
                                model.CorreoElectronico);

                if (result <= 0)
                {
                    ViewBag.Mensaje = "Su información no se registró correctamente.";
                    return View();
                }

                return RedirectToAction("Login", "Home");
            }
        }

        #endregion

        #region Recuperar Contraseña

        [HttpGet]
        public ActionResult RecuperarContrasenna()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecuperarContrasenna(UsuarioModel modelo)
        {
            // Aquí luego vas a implementar la lógica
            return View();
        }

        #endregion
    }
}