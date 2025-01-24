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
    public partial class insertarInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarAreas();
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            clUsuarioE oUusario = new clUsuarioE()
            {
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                tipoDocumento = ddlTipoDocumento.SelectedValue,
                documento = txtDocumento.Text,
                email = txtEmail.Text,
                idRol = 2
            };
            clArea oArea = new clArea()
            {
                idArea = int.Parse(ddlArea.SelectedValue)
            };
            clRegistrarInstructorL oLogica = new clRegistrarInstructorL();
            bool exito = oLogica.mtdRegistarI(oUusario, oArea);
            if (exito)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire('Registrado correctamente!');", true);
                limpiarFormulario();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire({\r\n  icon: \"error\",\r\n  title: \"Oops...\",\r\n  text: \"No se registro al instructor\",\r\n});\r\n", true);


            }
        }
        private void cargarAreas()
        {
            clRegistrarInstructorL oLogica = new clRegistrarInstructorL();
            List<clArea> lista = oLogica.mtdObtenerArea();
            ddlArea.Items.Clear();
            ddlArea.Items.Add(new ListItem("Seleccione Area", ""));
            if (lista != null && lista.Count > 0)
            {
                foreach (clArea area in lista)
                {
                    ddlArea.Items.Add(new ListItem(area.nombreArea, area.idArea.ToString()));
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire({\r\n  icon: \"error\",\r\n  title: \"Oops...\",\r\n  text: \"No se listaron areas\",\r\n});\r\n", true);


            }
        }
        private void limpiarFormulario()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDocumento.Text = "";
            txtEmail.Text = "";
            ddlArea.SelectedIndex = 0;
            ddlTipoDocumento.SelectedIndex = 0;
        }
    }
}