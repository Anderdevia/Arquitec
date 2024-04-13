using System.ComponentModel.DataAnnotations;
using System.Web;

namespace BE
{
    public class Producto

    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        private string nombre;
        //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo solo puede contener letras.")]
        [Required]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string descripcion;

        [Display(Name = "Descripción")]
        [Required]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private int referencia;
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo debe ser numérico.")]
        public int Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

        private int stock;

        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo debe ser numérico.")]
        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        private string categoria;
        [Required]
        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        private decimal precio;
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo debe ser numérico.")]
        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private int id_tipo;

        [Display(Name = "Tipo")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo debe ser numérico.")]
        public int Id_tipo
        {
            get { return id_tipo; }
            set { id_tipo = value; }
        }

        private int id_proveedor;

        [Display(Name = "Proveedor")]
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El campo debe ser numérico.")]
        public int Id_proveedor
        {
            get { return id_proveedor; }
            set { id_proveedor = value; }
        }

        private HttpPostedFileBase ruta_imagen;

       
        [Display(Name = "Ruta Imagen")]
        public HttpPostedFileBase Ruta_imagen
        {
            get { return ruta_imagen; }
            set { ruta_imagen = value; }
        }

        private string nombreImagen;
       
        public string NombreImagen
        {
            get { return nombreImagen; }
            set { nombreImagen = value; }
        }

        //public class ArtGallery
        //{
        //    public string GallerName { get; set; }
        //    public HttpPostedFileBase[] Documents { get; set; }
        //}
    }

}