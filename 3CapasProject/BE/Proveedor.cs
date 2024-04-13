using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Proveedor
    {
        private int id;

        [DisplayName("CODIGO")]
        [Required]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string empresa;

        [Display(Name = "Empresa")]
        [Required]
        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }

        private string nombre;

        [Display(Name = "Nombre")]
        [Required]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string cargo;

        [Display(Name = "Cargo")]
        [Required]
        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        private string districto;

        [Display(Name = "Descripción")]
        [Required]
        public string Districto
        {
            get { return districto; }
            set { districto = value; }
        }

        private int telefono;

        [Display(Name = "Descripción")]
        [Required]
        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }



    }
}
