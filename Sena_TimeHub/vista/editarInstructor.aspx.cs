using Sena_TimeHub.entidades;
using Sena_TimeHub.logica;
using Sena_TimeHub.logica.editar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sena_TimeHub.vista
{
    public partial class editarInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idURL = Request.QueryString["idUsuario"];
                if (!string.IsNullOrWhiteSpace(idURL))
                {
                    int id = int.Parse(idURL);
                    cargarCoordinacion(id);
                }
            }
        }
        private void cargarCoordinacion(int id)
        {

            clObtenerCoordinacionL oLogica = new clObtenerCoordinacionL();
            clUsuarioE oUsuario = oLogica.mtdObtenerC(id);
            if (oUsuario != null)
            {
                txtNombre.Text = oUsuario.nombre;
                txtApellido.Text = oUsuario.apellido;
                ddlTipoDocumento.SelectedValue = oUsuario.tipoDocumento;
                txtDocumento.Text = oUsuario.documento;
                txtEmail.Text = oUsuario.email;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire({\r\n  icon: \"error\",\r\n  title: \"Oops...\",\r\n  text: \"No se cargo el Instructor\",\r\n});\r\n", true);
            }

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            clActualizarInstructorL Ologica = new clActualizarInstructorL();
            clUsuarioE oUsuario = new clUsuarioE()
            {

                idUsuario = int.Parse(Request.QueryString["idUsuario"]),
                nombre = string.IsNullOrWhiteSpace(txtNombre.Text) ? null : txtNombre.Text,
                apellido = string.IsNullOrWhiteSpace(txtApellido.Text) ? null : txtApellido.Text,
                tipoDocumento = string.IsNullOrWhiteSpace(ddlTipoDocumento.SelectedValue) ? null : ddlTipoDocumento.SelectedValue,
                documento = string.IsNullOrWhiteSpace(txtDocumento.Text) ? null : txtDocumento.Text,
                email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text
            };
            bool exito = Ologica.mtdActI(oUsuario);
            if (exito)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
          "Swal.fire({ title: 'Se actualizó correctamente', icon: 'success' }).then(() => { window.location.href = 'listarInstructor.aspx'; });", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire({ icon: 'error',  title: 'Oops...',  text: 'NO se puedo Actualizar'});", true);

            }
        }
    }
}