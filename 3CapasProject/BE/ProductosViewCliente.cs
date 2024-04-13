using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ProductosViewCliente
    {

        private int id;

        [DisplayName("Id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string categoria;

        [DisplayName("Categoria")]
        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        private string descripcion;

        [DisplayName("Descripción")]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string nombre;

        [DisplayName("Nombre")]

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string precio;

        [DisplayName("Precio $")]
        public string Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private string stockActual;

        [DisplayName("Stock Actual")]
        public string StockActual
        {
            get { return stockActual; }
            set { stockActual = value; }
        }

        private string proveedor;

        [DisplayName("Proveedor")]
        public string Proveedor
        {
            get { return proveedor; }
            set { proveedor = value; }
        }

        private string nombreImagen;

        [DisplayName("Imagen de Producto")]
        public string NombreImagen
        {
            get { return nombreImagen; }
            set { nombreImagen = value; }
        }
    }
}
