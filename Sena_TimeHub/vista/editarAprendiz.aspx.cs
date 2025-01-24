using Sena_TimeHub.entidades;
using Sena_TimeHub.logica;
using System;
using System.Web.UI;

namespace Sena_TimeHub.vista
{
    public partial class editarAprendiz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idUsuarioURL = Request.QueryString["idUsuario"];
                if (!string.IsNullOrWhiteSpace(idUsuarioURL) && int.TryParse(idUsuarioURL, out int idUsuario))
                {
                    CargarAprendiz(idUsuario);
                }
                else
                {
                    MostrarMensaje("ID de usuario no válido.");
                }
            }
        }

        private void CargarAprendiz(int id)
        {
            try
            {
                clObtenerAprendicesLcs oLogica = new clObtenerAprendicesLcs();
                clUsuarioE oUsuario = oLogica.ObtenerAprendizPorId(id); 

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
                    MostrarMensaje("Usuario no encontrado.");
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar aprendiz: {ex.Message}");
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                clUsuarioE oUsuario = new clUsuarioE
                {
                    idUsuario = int.Parse(Request.QueryString["idUsuario"]),
                    nombre = string.IsNullOrWhiteSpace(txtNombre.Text) ? null : txtNombre.Text,
                    apellido = string.IsNullOrWhiteSpace(txtApellido.Text) ? null : txtApellido.Text,
                   tipoDocumento = string.IsNullOrWhiteSpace(ddlTipoDocumento.SelectedValue) ? null : ddlTipoDocumento.SelectedValue,
                    documento = string.IsNullOrWhiteSpace(txtDocumento.Text) ? null : txtDocumento.Text,
                    email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text,
                };

                clEditarAprendizL oLogica = new clEditarAprendizL();
                bool exito = oLogica.EditarAprendiz(oUsuario); // Método para actualizar aprendiz

                if (exito)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire('Aprendiz actualizado correctamente');", true);
                    Response.Redirect("listarAprendices.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire({\r\n  icon: \"error\",\r\n  title: \"Oops...\",\r\n  text: \"No se actualizo el aprendiz\",\r\n});\r\n", true);

                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al actualizar aprendiz: {ex.Message}");
            }
        }

        private void MostrarMensaje(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('{mensaje}');", true);
        }
    }
}
