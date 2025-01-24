using Sena_TimeHub.entidades;
using Sena_TimeHub.logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sena_TimeHub.vista
{
    public partial class insertarPrograma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"]==null && Session["rol"]==null)
                {
                    Response.Redirect("error.aspx");
                }
            }
        }
        protected void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            clProgramaE objPrograma = new clProgramaE
            {
                nombrePrograma = txtPrograma.Text,
                version = txtVersion.Text,
                codigo = txtCodigo.Text,
                tipo = txtTipo.Text
            };

            clProgramaL objProductoLo = new clProgramaL();
            objProductoLo.MtdRegistrarPrograma(objPrograma);

            if (objProductoLo != null)
            {

                pnlAlert.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire('Registrado correctamente!');", true);
                ClearFields();


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire({\r\n  icon: \"error\",\r\n  title: \"Oops...\",\r\n  text: \"No se registro\",\r\n});\r\n", true);

            }
        }
        private void ClearFields()
        {
            txtPrograma.Text = string.Empty;
            txtVersion.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtTipo.Text = string.Empty;
        }




    }

}