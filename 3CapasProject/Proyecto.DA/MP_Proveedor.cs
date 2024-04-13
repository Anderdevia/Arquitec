using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.DA
{
    public class MP_Proveedor
    {
        private AccesoDA ac = new AccesoDA();

        // Método para listar todos los proveedores
        public List<BE.Proveedor> listar()
        {
            // Utiliza el método Leer de AccesoDA para obtener los datos de todos los productos
            DataTable tabla = ac.Leer("Listar_Proveedor", null);
            List<BE.Proveedor> proveedores = new List<BE.Proveedor>();

            // Itera sobre cada fila del DataTable y crea un objeto Producto para cada registro
            foreach (DataRow registro in tabla.Rows)
            {
                BE.Proveedor proveedor = new BE.Proveedor();
                proveedor.Id = int.Parse(registro["id"].ToString());
                proveedor.Empresa = registro["empresa"].ToString();
                proveedor.Nombre = registro["nombre"].ToString();
                proveedor.Cargo = registro["cargo"].ToString();
                proveedor.Districto = registro["districto"].ToString();
                proveedor.Telefono = int.Parse(registro["telefono"].ToString());
                //categoria.Ruta_imagen = registro["ruta_imagen"].ToString();
                proveedores.Add(proveedor);
            }
            return proveedores;
        }
    }
}
