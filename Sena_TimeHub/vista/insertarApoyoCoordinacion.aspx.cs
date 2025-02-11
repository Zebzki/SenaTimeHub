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
    public partial class insertarApoyoCoordinacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            clUsuarioE oUSuario = new clUsuarioE()
            {
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                tipoDocumento = ddlTipoDocumento.SelectedValue,
                documento = txtDocumento.Text,
                email = txtEmail.Text,
                idRol = 3
            };
            clRegistrarCoordinacionL oRegistro = new clRegistrarCoordinacionL();
            bool exito = oRegistro.mtdRegistrar(oUSuario);
            if (exito)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire('Registrado correctamente!');", true);
                LimpiarFormulario();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire({\r\n  icon: \"error\",\r\n  title: \"Oops...\",\r\n  text: \"No se registro\",\r\n});\r\n", true);


            }
        }
        private void LimpiarFormulario()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            ddlTipoDocumento.SelectedIndex = 0;
            txtDocumento.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

    }
}