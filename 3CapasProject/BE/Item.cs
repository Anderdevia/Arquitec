using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Item
    {
        public int id;

      [DisplayName("Id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string nombre;

        [DisplayName("Nombre")]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string descripcion;

        [DisplayName("DESCRIPCION")]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public double precio;

        [DisplayName("Precio $")]
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public int cantidad;

        [DisplayName("CANTIDAD")]
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }


        [DisplayName("Subtotal")]
        public double Subtotal
        {
            get { return precio * cantidad; }
        }

        public string nombreImagen;

        [DisplayName("Imagen")]
        public string NombreImagen
        {
            get { return nombreImagen; }
            set { nombreImagen = value; }
        }
    }
}

