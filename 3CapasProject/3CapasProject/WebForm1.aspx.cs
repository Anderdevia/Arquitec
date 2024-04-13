using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3CapasProject
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Proyecto.BL.Persona gestor = new Proyecto.BL.Persona();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Enlazar();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            hid.Value = "0";
            limpiarCampos();
            limpiarlbl();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           
            limpiarlbl();
            if (string.IsNullOrWhiteSpace(hid.Value))
            {
                hid.Value = "0";
            }
            string nombres = txtNom.Text;
            string Apellidoss = txtApe.Text;
            string edadS =txtEda.Text;
            string cargos = txtCargo.Text;
            string sueldose = txtsue.Text;
            if (edadS == "" || edadS == null || sueldose == "" || sueldose == null || nombres =="" || nombres == null || Apellidoss =="" || Apellidoss == null || cargos =="" || cargos == null )
            {
                if (edadS == "" )
                {
                    lbledad.Text = "Campo Obligatorio";
                    lbledad.Visible = true;

                }
                if (sueldose == "")
                {
                    lblsueldo.Text = "Campo Obligatorio";
                    lblsueldo.Visible = true;

                }
                if (nombres == "")
                {
                    lblnom.Text = "Campo Obligatorio";
                    lblnom.Visible = true;

                }
                if (Apellidoss == "")
                {
                    lblapellido.Text = "Campo Obligatorio";
                    lblapellido.Visible = true;
                }
                if (cargos == "")
                {
                    lblCargo.Text = "Campo Obligatorio";
                    lblCargo.Visible = true;

                }

            }
            else { 
            int edad = Convert.ToInt32(txtEda.Text);



                if (edad < 18)
                {
                    lbledad.Text = "No se permiten menores de Edad";
                    lbledad.Visible = true;
                }
                else
                {

                        BE.Persona per = new BE.Persona();
                        per.Id = int.Parse(hid.Value);
                        per.Nombre = txtNom.Text;
                        per.Apellido = txtApe.Text;
                        per.Edad = txtEda.Text;
                        per.Cargo = txtCargo.Text;
                        per.Sueldo = txtsue.Text;

                        gestor.Grabar(per);
                        Enlazar();
                        limpiarCampos();

                    
                }

         
            }
            
        }

        public void Enlazar()
        {
            GridView1.DataSource = gestor.Listar();
            GridView1.DataBind();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           

            int id = int.Parse(GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].Text);
            BE.Persona per = gestor.Listar(id);
            switch (e.CommandName)
            {
                case "Borrar":
                    {
                        gestor.Borrar(per);
                        Enlazar();
                        break;
                    }
                case "Seleccionar":
                    {
                    
                        hid.Value = per.Id.ToString();
                        txtNom.Text = per.Nombre;
                        txtApe.Text = per.Apellido;
                        txtEda.Text = per.Edad.ToString();
                        txtCargo.Text = per.Cargo;
                        txtsue.Text = per.Sueldo.ToString();
                        break;
                    }



            }

        }
        public void limpiarlbl()
        {
            lblnom.Text="";
            lblapellido.Text="";
            lbledad.Text="";
            lblCargo.Text="";
            lblsueldo.Text="";
        }
        public void limpiarCampos()
        {
            txtNom.Text = "";
            txtApe.Text = "";
            txtEda.Text = "";
            txtCargo.Text = "";
            txtsue.Text = "";
        }
       


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}