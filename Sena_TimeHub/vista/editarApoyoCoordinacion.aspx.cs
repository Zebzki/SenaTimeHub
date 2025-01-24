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
    public partial class editarApoyoCoordinacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idUsuarioURL = Request.QueryString["idUsuario"];
                if (!string.IsNullOrWhiteSpace(idUsuarioURL))
                {
                    int idUsuario = int.Parse(idUsuarioURL);
                    cargarCoordinacion(idUsuario);
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire('Ususario no encontrado');", true);
            }

        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            clUsuarioE oUsuario = new clUsuarioE();
            
            oUsuario.idUsuario = int.Parse(Request.QueryString["idUsuario"]);
            oUsuario.nombre = string.IsNullOrWhiteSpace(txtNombre.Text) ? null : txtNombre.Text;
            oUsuario.apellido = string.IsNullOrWhiteSpace(txtApellido.Text) ? null : txtApellido.Text;
            oUsuario.tipoDocumento  = string.IsNullOrWhiteSpace(ddlTipoDocumento.SelectedValue) ? null : ddlTipoDocumento.SelectedValue;
            oUsuario.documento = string.IsNullOrWhiteSpace(txtDocumento.Text) ? null : txtDocumento.Text;
            oUsuario.email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text;
            clActualizarCoordinacionL oLogica = new clActualizarCoordinacionL();
            bool exito = oLogica.mtdActualizarC(oUsuario);
            if (exito)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire('Apoyo de Coordinacion eliminado correctamnete!');", true);
                Response.Redirect("listarApoyoCoordinacion.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire({\r\n  icon: \"error\",\r\n  title: \"Oops...\",\r\n  text: \"No se pudo actualizar\",\r\n});\r\n", true);


            }
        }
    }
}