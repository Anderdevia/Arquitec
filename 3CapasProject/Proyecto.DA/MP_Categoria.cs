using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Proyecto.DA
{
    public class MP_Categoria
    {
        private AccesoDA ac = new AccesoDA();

        // Método para listar todos los productos
        public List<BE.Categoria> listar()
        {
            // Utiliza el método Leer de AccesoDA para obtener los datos de todos los productos
            DataTable tabla = ac.Leer("Listar_Categoria", null);
            List<BE.Categoria> categorias = new List<BE.Categoria>();

            // Itera sobre cada fila del DataTable y crea un objeto Producto para cada registro
            foreach (DataRow registro in tabla.Rows)
            {
                BE.Categoria categoria = new BE.Categoria();
                categoria.Codigo = int.Parse(registro["id"].ToString());
                categoria.Nombre = registro["nombre"].ToString();
                categoria.Descripcion = registro["descripcion"].ToString();
                //categoria.Ruta_imagen = registro["ruta_imagen"].ToString();
                categorias.Add(categoria);
            }
            return categorias;
        }

        // Método para listar los menus de administrador
        public List<BE.MenuAdmin> listarMenu()
        {
            // Utiliza el método Leer de AccesoDA para obtener los datos de todos los productos
            DataTable tabla = ac.Leer("sp_getmodulos_admin", null);
            List<BE.MenuAdmin> menus = new List<BE.MenuAdmin>();

            // Itera sobre cada fila del DataTable y crea un objeto menu para mostrar
            foreach (DataRow registro in tabla.Rows)
            {
                BE.MenuAdmin menu = new BE.MenuAdmin();
                menu.Id = int.Parse(registro["id"].ToString());
                menu.Controlador = registro["controlador"].ToString();
                menu.Nombre = registro["nombre"].ToString();
                menu.Ver = int.Parse(registro["ver"].ToString());
    
                menus.Add(menu);
            }
            return menus;
        }

        // Método para insertar un nuevo producto
        //public int Insertar(BE.Producto producto)
        //{
        //    // Crea una lista de parámetros para enviar al método Escribir de AccesoDA
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    parameters.Add(ac.CrearParametro("@nombre", producto.Nombre));
        //    parameters.Add(ac.CrearParametro("@descripcion", producto.Descripcion));
        //    parameters.Add(ac.CrearParametro("@referencia", producto.Referencia.ToString()));
        //    parameters.Add(ac.CrearParametro("@stock", producto.Stock.ToString()));
        //    parameters.Add(ac.CrearParametro("@categoria", producto.Categoria));
        //    parameters.Add(ac.CrearParametro("@precio", producto.Precio.ToString()));
        //    parameters.Add(ac.CrearParametro("@id_tipo", producto.Id_tipo.ToString()));
        //    parameters.Add(ac.CrearParametro("@id_proveedor", producto.Id_proveedor.ToString()));
        //    //parameters.Add(ac.CrearParametro("@ruta_imagen", producto.Ruta_imagen));

        //    // Utiliza el método Escribir de AccesoDA para ejecutar la inserción y retorna el resultado
        //    return ac.Escribir("Insertar_Productos", parameters);
        //}
    }
}
