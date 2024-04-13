using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Categoria
    {

        private int codigo;

        [Required]
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }


        private string nombre;
        //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo solo puede contener letras.")]
        [Display(Name = "Nombre")]
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
    }
}
