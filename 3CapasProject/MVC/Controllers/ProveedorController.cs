using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class ProveedorController : Controller
    {
        // Instancia del gestor de productos desde la capa de negocio
        Proyecto.BL.Proveedor gestor = new Proyecto.BL.Proveedor();

        // GET: Proveedor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {
            // Llama al método Listar() del gestor para obtener la lista de productos
            var Categorias = gestor.Listar();

            // Retorna la vista "Index" con la lista de Categorias como modelo
            return View(Categorias);
        }


        [HttpGet]
        public JsonResult GetComboProveedor()
        {
            var Proveedores = gestor.Listar();
            List<Proveedor> data = new List<Proveedor>();

            foreach (var dr in Proveedores)
            {
                Proveedor obj = new Proveedor()
                {
                    Id = int.Parse(dr.Id.ToString()), // Asumiendo que el primer elemento de dr es el código
                    Nombre = dr.Nombre.ToString()             // Asumiendo que el segundo elemento de dr es el nombre
                };
                data.Add(obj);
            }

            return Json(data, JsonRequestBehavior.AllowGet);


        }
    }
}