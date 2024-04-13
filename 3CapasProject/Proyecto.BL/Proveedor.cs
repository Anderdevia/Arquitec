using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.BL
{
    public class Proveedor
    {
        // Instancia del acceso a datos para la capa de datos
        Proyecto.DA.MP_Proveedor MP = new DA.MP_Proveedor();

        public List<BE.Proveedor> Listar()
        {
            // Llama al método listar() de la capa de datos para recuperar la lista de productos
            return MP.listar();
        }
    }
}
