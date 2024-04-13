using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.DA
{
    public class MP_ProductoTienda
    {
        // Instancia del acceso a la base de datos general para esta clase
        private AccesoDA ac = new AccesoDA();

        // Método para listar todos los productos
        public List<BE.ProductosViewCliente> listar()
        {
            // Utiliza el método Leer de AccesoDA para obtener los datos de todos los productos
            DataTable tabla = ac.Leer("Lista_ProductosTienda", null);
            List<BE.ProductosViewCliente> productos = new List<BE.ProductosViewCliente>();

            // Itera sobre cada fila del DataTable y crea un objeto Producto para cada registro
            foreach (DataRow registro in tabla.Rows)
            {
                BE.ProductosViewCliente producto = new BE.ProductosViewCliente();
                producto.Id = int.Parse(registro["id"].ToString());
                producto.Nombre = registro["nombre"].ToString();
                producto.Descripcion = registro["descripcion"].ToString();
                producto.StockActual = registro["stock"].ToString();
                producto.Categoria = registro["nombre"].ToString();
                producto.Precio = registro["precio"].ToString();
                producto.Proveedor = registro["empresa"].ToString();
                producto.NombreImagen = registro["ruta_imagen"].ToString();
                productos.Add(producto);
            }
            return productos;
        }
    }
}
