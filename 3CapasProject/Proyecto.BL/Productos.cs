using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.BL
{
    public class Productos
    {
        // Instancia del acceso a datos para productos desde la capa de datos
        Proyecto.DA.MP_Producto MP = new DA.MP_Producto();

        // Método para guardar o actualizar un producto
        public int Grabar(BE.Producto persona)
        {
            int res = 0;
            // Verifica si el ID del producto es 0 (nuevo producto)
            if (persona.Id == 0)
            {
                // Llama al método Insertar() de la capa de datos para agregar el nuevo producto
                res = MP.Insertar(persona);
            }
            else
            {
                // Llama al método Editar() de la capa de datos para actualizar el producto existente
                res = MP.Editar(persona);
            }
            // Retorna el resultado de la operación (número de filas afectadas)
            return res;
        }

        // Método para eliminar un producto
        public int Borrar(int id)
        {
            // Llama al método Borrar() de la capa de datos para eliminar el producto
            return MP.Borrar(id);
        }

        // Método para obtener una lista de todos los productos
        public List<BE.Producto> Listar()
        {
            // Llama al método listar() de la capa de datos para recuperar la lista de productos
            return MP.listar();
        }

        // Método para obtener un producto específico basado en su ID
        public BE.Producto Listar(int id)
        {
            // Llama al método Listar(id) de la capa de datos para recuperar un producto específico
            return MP.Listar(id);
        }
    }
}
