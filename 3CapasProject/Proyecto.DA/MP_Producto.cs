using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Proyecto.DA
{
    public class MP_Producto
    {
        // Instancia del acceso a la base de datos general para esta clase
        private AccesoDA ac = new AccesoDA();

        // Método para listar todos los productos
        public List<BE.Producto> listar()
        {
            // Utiliza el método Leer de AccesoDA para obtener los datos de todos los productos
            DataTable tabla = ac.Leer("Listar_Productos", null);
            List<BE.Producto> productos = new List<BE.Producto>();

            // Itera sobre cada fila del DataTable y crea un objeto Producto para cada registro
            foreach (DataRow registro in tabla.Rows)
            {
                BE.Producto producto = new BE.Producto();
                producto.Id = int.Parse(registro["id"].ToString());
                producto.Nombre = registro["nombre"].ToString();
                producto.Descripcion = registro["descripcion"].ToString();
                producto.Stock = Convert.ToInt32(registro["stock"].ToString());
                producto.Referencia = Convert.ToInt32(registro["referencia"].ToString());
                producto.Categoria = registro["categoria"].ToString();
                producto.Precio = Convert.ToDecimal(registro["precio"].ToString());
                producto.Id_tipo = Convert.ToInt32(registro["id_tipo"].ToString());
                producto.Id_proveedor = Convert.ToInt32(registro["id_proveedor"].ToString());
                producto.NombreImagen = registro["ruta_imagen"].ToString();
                productos.Add(producto);
            }
            return productos;
        }

        // Método para insertar un nuevo producto
        public int Insertar(BE.Producto producto)
        {
           
            // Crea una lista de parámetros para enviar al método Escribir de AccesoDA
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(ac.CrearParametro("@nombre", producto.Nombre));
            parameters.Add(ac.CrearParametro("@descripcion", producto.Descripcion));
            parameters.Add(ac.CrearParametro("@referencia", producto.Referencia.ToString()));
            parameters.Add(ac.CrearParametro("@stock", producto.Stock.ToString()));
            parameters.Add(ac.CrearParametro("@categoria", producto.Categoria));
            parameters.Add(ac.CrearParametro("@precio", producto.Precio.ToString()));
            parameters.Add(ac.CrearParametro("@id_tipo", producto.Id_tipo.ToString()));
            parameters.Add(ac.CrearParametro("@id_proveedor", producto.Id_proveedor.ToString()));
            parameters.Add(ac.CrearParametro("@ruta_imagen", producto.NombreImagen.ToString()));

            // Utiliza el método Escribir de AccesoDA para ejecutar la inserción y retorna el resultado
            return ac.Escribir("Insertar_Productos", parameters);
        }

        // Método para editar un producto existente
        public int Editar(BE.Producto producto)
        {
            // Crea una lista de parámetros para enviar al método Escribir de AccesoDA
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(ac.CrearParametro("@id", producto.Id.ToString()));
            parameters.Add(ac.CrearParametro("@nombre", producto.Nombre));
            parameters.Add(ac.CrearParametro("@descripcion", producto.Descripcion));
            parameters.Add(ac.CrearParametro("@referencia", producto.Referencia.ToString()));
            parameters.Add(ac.CrearParametro("@stock", producto.Stock.ToString()));
            parameters.Add(ac.CrearParametro("@categoria", producto.Categoria));
            parameters.Add(ac.CrearParametro("@precio", producto.Precio.ToString()));
            parameters.Add(ac.CrearParametro("@id_tipo", producto.Id_tipo.ToString()));
            parameters.Add(ac.CrearParametro("@id_proveedor", producto.Id_proveedor.ToString()));
            parameters.Add(ac.CrearParametro("@ruta_imagen", producto.NombreImagen.ToString()));

            // Utiliza el método Escribir de AccesoDA para ejecutar la actualización y retorna el resultado
            return ac.Escribir("Editar_Productos", parameters);
        }

        // Método para borrar un producto
        public int Borrar(int id)
        {
            // Crea una lista de parámetros para enviar al método Escribir de AccesoDA
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(ac.CrearParametro("@id", id.ToString()));

            // Utiliza el método Escribir de AccesoDA para ejecutar el borrado y retorna el resultado
            return ac.Escribir("Eliminar_Productos", parameters);
        }

        // Método para obtener un producto específico por su ID
        public BE.Producto Listar(int ID)
        {
            // Convierte el ID a string para crear el parámetro
            string valorecibido = Convert.ToString(ID);
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(ac.CrearParametro("@id", valorecibido));

            // Utiliza el método Leer de AccesoDA para obtener el producto específico
            DataTable tabla = ac.Leer("Seleccionar_Producto", parameters);
            BE.Producto producto = new BE.Producto();

            // Crea un objeto Producto con los datos obtenidos del registro y lo retorna
            DataRow registro = tabla.Rows[0];
            producto.Id = int.Parse(registro["id"].ToString());
            producto.Nombre = registro["nombre"].ToString();
            producto.Descripcion = registro["descripcion"].ToString();
            producto.Referencia = Convert.ToInt32(registro["referencia"].ToString());
            producto.Categoria = registro["categoria"].ToString();
            producto.Precio = Math.Floor(Convert.ToDecimal(registro["precio"].ToString()));
            producto.Stock = Convert.ToInt32(registro["stock"].ToString());
            producto.Id_proveedor = Convert.ToInt32(registro["id_proveedor"].ToString());
            producto.NombreImagen = registro["ruta_imagen"].ToString();


            return producto;
        }
    }
}
