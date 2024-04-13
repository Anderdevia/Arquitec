using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.BL
{
   public class Login
    {
        // Instancia del acceso a datos para productos desde la capa de datos
        Proyecto.DA.MP_Login MP = new DA.MP_Login();

        // Método para obtener un producto específico basado en su ID
        public BE.Usuarios AccessLogin(string correo, string contraseña)
        {
            // Llama al método Listar(id) de la capa de datos para recuperar un producto específico
            return MP.Listar(correo,contraseña);
        }
    }
}
