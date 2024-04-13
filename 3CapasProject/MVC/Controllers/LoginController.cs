using Proyecto.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {
        // Instancia del gestor de Login desde la capa de negocio
        Proyecto.BL.Login gestor = new Proyecto.BL.Login();

        // GET: Login
        public ActionResult AccesLogin()
        {
            ViewBag.Nombre_Login = Constantes.Sources._NOMBRE_LOGIN;
            ViewBag.Message = "";
            return View();
        }

        // Método para acceder despues de logearse
        [HttpPost]
        public ActionResult AccesLogin(string correo, string contraseña)
        {
            ViewBag.Nombre_Login = Constantes.Sources._NOMBRE_LOGIN;
            // Llama al método AccessLogin(id) del gestor para obtener el producto específico
            if (correo != null)
            {
                var productos = gestor.AccessLogin(correo, contraseña);



                if (productos.UsuarioLogin == null)
                {
                    ViewBag.Message = "Acceso denegado, credenciales incorrectas. ";
                    return View();
                    //return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
                else if (!string.IsNullOrEmpty(productos.UsuarioLogin))
                {

                    FormsAuthentication.SetAuthCookie(productos.UsuarioLogin, false);
                    Session["Usuario"] = productos.UsuarioLogin;
                    ViewBag.Usuario = productos.UsuarioLogin;
                    return RedirectToAction("Index", "Productos");
                    //return Json( new { success = true }, JsonRequestBehavior.AllowGet);


                }
                else
                {

                    ViewBag.Message = "";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "";
                return View();
            }
            //return (result.Succeed)

            //return Json(productos, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult CerrarSesion()
        {

            FormsAuthentication.SignOut();
            Session["Usuario"] = null;

            ViewBag.Message = "";
            return RedirectToAction("AccesLogin", "Login");



        }
    }
}