using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class ProductosController : Controller
    {
        // Instancia del gestor de productos desde la capa de negocio
        Proyecto.BL.Productos gestor = new Proyecto.BL.Productos();
        Proyecto.BL.Categoria gestorCateg = new Proyecto.BL.Categoria();
        Proyecto.BL.Proveedor gestorProve = new Proyecto.BL.Proveedor();



        // Método para mostrar la lista de productos en la vista "Index"
        public ActionResult Index()
        {

            // Retorna la vista "Index" con la lista de productos como modelo
            return View();
        }

        // Método para mostrar la lista de productos en la vista "Productos"
        public ActionResult Productos()
        {
            // Llama al método Listar() del gestor para obtener la lista de productos
            var Productos = gestor.Listar();

            // Retorna la vista "Index" con la lista de productos como modelo
            return View();
        }

        // Método para mostrar la vista de creación de productos
        public ActionResult Crear()
        {
            // Retorna la vista de creación de productos
            return View();
        }


        // Método para mostrar la vista de detalle de productos
        public ActionResult Details(int id)
        {
            // Llama al método Listar(id) del gestor para obtener el producto específico
            BE.Producto productos = gestor.Listar(id);

            return View(productos);
        }


        // Método POST para crear un nuevo producto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(BE.Producto producto)
        {
            // Llama al método Grabar() del gestor para guardar el nuevo producto
            gestor.Grabar(producto);

            // Redirige al usuario al método "Index" después de crear el producto
            return RedirectToAction("Crear");
        }

        // Método para mostrar la vista de edición de productos basado en un ID
        public ActionResult Update(int id)
        {
            // Llama al método Listar(id) del gestor para obtener el producto específico
           var productos = gestor.Listar(id);
        
            return Json(productos, JsonRequestBehavior.AllowGet);
        }

        // Método POST para actualizar un producto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(BE.Producto producto)
        {
            // Llama al método Grabar() del gestor para actualizar el producto
            gestor.Grabar(producto);

            // Redirige al usuario al método "Index" después de actualizar el producto
            return RedirectToAction("Index");
        }

        // Método para mostrar la vista de confirmación de eliminación basado en un ID
        public ActionResult Delete(int id)
        {
            // Llama al método Listar(id) del gestor para obtener el producto específico
            var idRespuesta = gestor.Borrar(id);

            var productos = gestor.Listar();
            List<Producto> data = new List<Producto>();

            foreach (var dr in productos)
            {
                Producto obj = new Producto()
                {
                    Id = int.Parse(dr.Id.ToString()), // Asumiendo que el primer elemento de dr es el código
                    Nombre = dr.Nombre.ToString(),         // Asumiendo que el segundo elemento de dr es el nombre
                    Descripcion = dr.Descripcion.ToString(),
                    Precio = decimal.Parse(dr.Precio.ToString()),
                    Stock = int.Parse(dr.Stock.ToString()),
                    Categoria = dr.Categoria.ToString(),
                    Id_proveedor = int.Parse(dr.Id_proveedor.ToString()),
                    NombreImagen = dr.NombreImagen.ToString()
                };
                data.Add(obj);
            }
            // Retorna la vista de confirmación de eliminación con el producto como modelo
            return Json(data, JsonRequestBehavior.AllowGet);
            
        }

        // Método POST para eliminar un producto
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(BE.Producto producto)
        //{
        //    // Llama al método Borrar() del gestor para eliminar el producto
        //    gestor.Borrar(producto);

        //    // Redirige al usuario al método "Index" después de eliminar el producto
        //    return RedirectToAction("Index");
        //}

        public ActionResult nuevoProducto(Producto producto, HttpPostedFileBase Imagen)
        {
            //se agrega el modelo para realizar el registro del producto nuevo
            gestor.Grabar(producto);


            return Json(new { success = true }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult imagenProducto(Producto producto, HttpPostedFileBase Imagen)
        {
            // se agrega la ruta local para poder grabr las imagenes dentro del sistem y asi se puedan recuperar 
            Imagen.SaveAs(Path.Combine(Server.MapPath("~/img/"),
            Path.GetFileName(Imagen.FileName)));
            return Content("1");

        }


        public ActionResult actualizaProducto(Producto producto, string imagen)
        { 
            if(producto.NombreImagen != imagen)
            {
               string rutaDirectorio = Path.Combine(Server.MapPath(""+ imagen));


            if (System.IO.File.Exists(rutaDirectorio))
            {
                System.IO.File.Delete(rutaDirectorio);
                // return Json(new { success = true, message = $"File '{rutaDirectorio}' deleted." });
            }
            else
            {
                //return Json(new { success = false, message = $"File '{rutaDirectorio}' not found." });
            }
            }

           

            //se agrega el modelo para realizar el registro del producto nuevo
            gestor.Grabar(producto);


            return Json(new { success = true }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ListaProducto()
        {
            var productos = gestor.Listar();
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

        [HttpGet]
        public JsonResult GetComboCategoria()
        {
            var Categorias = gestorCateg.Listar();
            List<Categoria> data = new List<Categoria>();

            foreach (var dr in Categorias)
            {
                Categoria obj = new Categoria()
                {
                    Codigo = int.Parse(dr.Codigo.ToString()), // Asumiendo que el primer elemento de dr es el código
                    Nombre = dr.Nombre.ToString()             // Asumiendo que el segundo elemento de dr es el nombre
                };
                data.Add(obj);
            }

            return Json(data, JsonRequestBehavior.AllowGet);


        }

        [HttpGet]
        public JsonResult GetComboProveedor()
        {
            var Proveedores = gestorProve.Listar();
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

        // Método para mostrar la lista de los menus 
        public ActionResult ListarMenu()
        {
            var menus = gestorCateg.ListarMenus();
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
    }
}
