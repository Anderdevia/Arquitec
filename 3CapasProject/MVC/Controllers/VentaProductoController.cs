using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class VentaProductoController : Controller
    {

        Proyecto.BL.ProductoTienda gestor = new Proyecto.BL.ProductoTienda();


        // GET: VentaProducto
        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        //Carrito de Compras
        public ActionResult carritoCompras()
        {
            if (Session["carrito"] == null)
            {
                Session["carrito"] = new List<Item>();
            }
            return View(ListProductos());
        }

        public ActionResult ListaProducto()
        {

            var productos = gestor.Listar();
            List<ProductosViewCliente> data = new List<ProductosViewCliente>();

            foreach (var dr in productos)
            {
                ProductosViewCliente obj = new ProductosViewCliente()
                {
                    Id = int.Parse(dr.Id.ToString()), // Asumiendo que el primer elemento de dr es el código
                    Nombre = dr.Nombre.ToString(),         // Asumiendo que el segundo elemento de dr es el nombre
                    Descripcion = dr.Descripcion.ToString(),
                    Precio = dr.Precio.ToString(),
                    StockActual = dr.StockActual.ToString(),
                    Categoria = dr.Categoria.ToString(),
                    Proveedor = dr.Proveedor.ToString(),
                    NombreImagen = dr.NombreImagen.ToString()
                };
                data.Add(obj);
            }



            return Json(data, JsonRequestBehavior.AllowGet);
        }


        //LISTADO GENERAL
        List<ProductosViewCliente> ListProductos()
        {
            var productos = gestor.Listar();
            List<ProductosViewCliente> data = new List<ProductosViewCliente>();

            foreach (var dr in productos)
            {
                ProductosViewCliente obj = new ProductosViewCliente()
                {
                    Id = int.Parse(dr.Id.ToString()), // Asumiendo que el primer elemento de dr es el código
                    Nombre = dr.Nombre.ToString(),         // Asumiendo que el segundo elemento de dr es el nombre
                    Descripcion = dr.Descripcion.ToString(),
                    Precio = dr.Precio.ToString(),
                    StockActual = dr.StockActual.ToString(),
                    Categoria = dr.Categoria.ToString(),
                    Proveedor = dr.Proveedor.ToString(),
                    NombreImagen = dr.NombreImagen.ToString()
                };
                data.Add(obj);
            }

         
            return data;
        }

        //Metodo que lista los item en formato Json
        public ActionResult ListaItem()
        {

            if (Session["carrito"] == null)
            {
                return RedirectToAction("Inicio");
            }
            var carrito = (List<Item>)Session["carrito"];
            var monto = carrito.Sum(p => p.Subtotal);

            return Json(carrito, JsonRequestBehavior.AllowGet);

        }

        public ActionResult actualizarTotal()
        {
            if (Session["carrito"] == null)
            {
                return RedirectToAction("Inicio");
            }
            var carrito = (List<Item>)Session["carrito"];
            var monto = carrito.Sum(p => p.Subtotal);

            return Json(monto, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Comprar()
        {
            if (Session["carrito"] == null)
            {
                return RedirectToAction("Inicio");
            }
            var carrito = (List<Item>)Session["carrito"];
            ViewBag.monto = carrito.Sum(p => p.Subtotal);
            return View(carrito);


        }
    }
}