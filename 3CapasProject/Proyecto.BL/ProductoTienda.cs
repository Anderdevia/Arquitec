using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.BL
{
    public class ProductoTienda
    {
        // Instancia del acceso a datos para productos desde la capa de datos
        Proyecto.DA.MP_ProductoTienda MP = new DA.MP_ProductoTienda();

        // Método para obtener una lista de todos los productos
        public List<BE.ProductosViewCliente> Listar()
        {
            // Llama al método listar() de la capa de datos para recuperar la lista de productos
            return MP.listar();
        }

    }
}
