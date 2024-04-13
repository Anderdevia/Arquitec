using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.DA
{
    public class MP_Login
    {
        // Instancia del acceso a la base de datos general para esta clase
        private AccesoDA ac = new AccesoDA();

        // Método para obtener un producto específico por su ID
        public BE.Usuarios Listar(string correo, string contraseña)
        {
            
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(ac.CrearParametro("@correo", correo));
            parameters.Add(ac.CrearParametro("@contraseña", contraseña));

            // Utiliza el método Leer de AccesoDA para obtener el producto específico
            DataTable tabla = ac.Leer("sp_access_login", parameters);
            BE.Usuarios usuario = new BE.Usuarios();

            if(tabla.Rows.Count >0)
            {
                // Crea un objeto usuario con los datos obtenidos del registro y lo retorna
                DataRow registro = tabla.Rows[0];
                usuario.Contraseña = registro["contraseña"].ToString();
                usuario.Correo = registro["correo"].ToString();
                usuario.IdRol = (Rol)registro["idRol"];
                usuario.UsuarioLogin = registro["usuario"].ToString();
            }else
            {

            }

           


            return usuario;
        }



    }
}
