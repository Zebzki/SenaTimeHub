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
                clObtenerAprendicesYUsuariosLcs oLogica = new clObtenerAprendicesYUsuariosLcs();
                clAprendizE oUsuario = oLogica.ObtenerAprendizPorId(id);

                if (oUsuario != null)
                {
                    txtNombre.Text = oUsuario.nombreAprendiz;
                    txtApellido.Text = oUsuario.apellidoAprendiz;
                    ddlTipoDocumento.SelectedValue = oUsuario.tipoDocumentoAprendiz;
                    txtDocumento.Text = oUsuario.documentoAprendiz ;
                    txtEmail.Text = oUsuario.emailAprendiz;
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
                clAprendizE oUsuario = new clAprendizE
                {
                    idAprendiz = int.Parse(Request.QueryString["idUsuario"]),
                    nombreAprendiz = string.IsNullOrWhiteSpace(txtNombre.Text) ? null : txtNombre.Text,
                    apellidoAprendiz = string.IsNullOrWhiteSpace(txtApellido.Text) ? null : txtApellido.Text,
                    tipoDocumentoAprendiz = string.IsNullOrWhiteSpace(ddlTipoDocumento.SelectedValue) ? null : ddlTipoDocumento.SelectedValue,
                    documentoAprendiz = string.IsNullOrWhiteSpace(txtDocumento.Text) ? null : txtDocumento.Text,
                    emailAprendiz = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text,
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