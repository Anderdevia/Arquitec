using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.BL
{
    public class Categoria
    {
        // Instancia del acceso a datos para productos desde la capa de datos
        Proyecto.DA.MP_Categoria MP = new DA.MP_Categoria();

        // Método para guardar o actualizar un producto
        //public int Grabar(BE.Producto persona)
        //{
        //    int res = 0;
        //    // Verifica si el ID del producto es 0 (nuevo producto)
        //    if (persona.Id == 0)
        //    {
        //        // Llama al método Insertar() de la capa de datos para agregar el nuevo producto
        //        res = MP.Insertar(persona);
        //    }
        //    else
        //    {
        //        // Llama al método Editar() de la capa de datos para actualizar el producto existente
        //        res = MP.Editar(persona);
        //    }
        //    // Retorna el resultado de la operación (número de filas afectadas)
        //    return res;
        //}

        public List<BE.Categoria> Listar()
        {
            // Llama al método listar() de la capa de datos para recuperar la lista de productos
            return MP.listar();
        }

        public List<BE.MenuAdmin> ListarMenus()
        {
            // Llama al método listar() de la capa de datos para recuperar la lista de productos
            return MP.listarMenu();
        }


    }
}
