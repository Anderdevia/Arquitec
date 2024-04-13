using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public partial class HomeController : Controller
    {
        CategoriaController gestor = new CategoriaController();
        ProductosController ControlProduct = new ProductosController();
        Proyecto.BL.Categoria gestorCate = new Proyecto.BL.Categoria();
        Proyecto.BL.Productos gestorProd = new Proyecto.BL.Productos();

        public ActionResult Index()
        {
           
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Mostrar ventana de Productos
        public ActionResult Productos()
        {
            //ViewBag.Message = "Your contact page.";
            ControlProduct.Productos();

            return View();
        }


        //public ActionResult ListaMenu()
        //{
        //    // Llama al método Listar() del gestor para obtener la lista de productos
        //    var Menus = gestor.ListarMenu();

        //    // Retorna los datos del menu
        //    return Json(Menus, JsonRequestBehavior.AllowGet);

        //}

        // Método para mostrar la lista de los menus 
        public ActionResult ListarMenu()
        {
            var menus = gestorCate.ListarMenus();
            List<MenuAdmin> data = new List<MenuAdmin>();

            foreach (var dr in menus)
            {
                MenuAdmin obj = new MenuAdmin()
                {
                    Id = int.Parse(dr.Id.ToString()),
                    Controlador = dr.Controlador.ToString(),
                    Nombre = dr.Nombre.ToString(),
                    Ver = int.Parse(dr.Ver.ToString())
                };
                data.Add(obj);
            }

            return Json(data, JsonRequestBehavior.AllowGet);


        }


        public ActionResult ListaProducto()
        {
            var productos = gestorProd.Listar();
            List<Producto> data = new List<Producto>();

            foreach (var dr in productos)
            {
                Producto obj = new Producto()
                {
                    Id = int.Parse(dr.Id.ToString()),
                    Nombre = dr.Nombre.ToString(),
                    Descripcion = dr.Descripcion.ToString(),
                    Precio = decimal.Parse(dr.Precio.ToString()),
                    Stock = int.Parse(dr.Stock.ToString()),
                    Categoria = dr.Categoria.ToString(),
                    Id_proveedor = int.Parse(dr.Id_proveedor.ToString()),
                    NombreImagen = dr.NombreImagen.ToString()
                };
                data.Add(obj);
            }

            return Json(data, JsonRequestBehavior.AllowGet);


        }



    }
}