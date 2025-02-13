using Sena_TimeHub.entidades;
using Sena_TimeHub.logica;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sena_TimeHub.vista
{
    public partial class insertarAprendiz : System.Web.UI.Page
    {
        private clRegistarAprendizL registroAprendizLogica = new clRegistarAprendizL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarFichasI();

                // Verifica si hay una alerta que mostrar después de la carga
                if (Session["RegistroExitoso"] != null)
                {
                    if ((bool)Session["RegistroExitoso"])
                    {
                        MostrarAlerta("Registrado correctamente!", "success");
                    }
                    else
                    {
                        MostrarAlerta("No se registró el aprendiz", "error");
                    }

                    // Limpia el estado de la sesión
                    Session["RegistroExitoso"] = null;
                }
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            clAprendizE oUsuario = new clAprendizE()
            {
                nombreAprendiz = txtNombre.Text,
                apellidoAprendiz = txtApellido.Text,
                tipoDocumentoAprendiz = ddlTipoDocumento.SelectedValue,
                documentoAprendiz = txtDocumento.Text,
                emailAprendiz = txtEmail.Text,
            };
            clFichaE oFicha = new clFichaE()
            {
                idFicha = int.Parse(ddlFicha.SelectedValue)
            };

            bool registroExitoso = registroAprendizLogica.RegistrarAprendiz(oUsuario, oFicha);

            // Almacena el resultado del registro en la sesión
            Session["RegistroExitoso"] = registroExitoso;

            if (registroExitoso)
            {
                LimpiarFormulario();
            }

            // Recarga la página para mostrar la alerta correspondiente
            Response.Redirect(Request.RawUrl);
        }

        private void CargarFichasI()
        {
            List<clFichaE> listarFichas = registroAprendizLogica.ObtenerFichas();

            ddlFicha.Items.Clear();
            ddlFicha.Items.Add(new ListItem("Seleccione ficha", ""));
            if (listarFichas != null && listarFichas.Count > 0)
            {
                foreach (clFichaE ficha in listarFichas)
                {
                    string texto = $"{ficha.numeroFicha} - {ficha.nombrePrograma}";
                    ddlFicha.Items.Add(new ListItem(texto, ficha.idFicha.ToString()));
                }
            }
            else
            {
                MostrarAlerta("Error al cargar las fichas", "error");
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            ddlTipoDocumento.SelectedIndex = 0;
            txtDocumento.Text = "";
            txtEmail.Text = "";
            ddlFicha.SelectedIndex = 0;
        }

        private void MostrarAlerta(string mensaje, string tipo)
        {
            string script = tipo == "success"
                ? $"Swal.fire('{mensaje}', '', '{tipo}');"
                : $"Swal.fire({{ icon: '{tipo}', title: 'Oops...', text: '{mensaje}' }});";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", script, true);
        }
    }
}
