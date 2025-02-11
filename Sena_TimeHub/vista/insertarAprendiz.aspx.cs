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
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            clAprendizE oAprendiz = new clAprendizE()
            {
                nombreAprendiz = txtNombre.Text,
                apellidoAprendiz = txtApellido.Text,
                tipoDocumentoAprendiz = ddlTipoDocumento.SelectedValue,
                documentoAprendiz = txtDocumento.Text,
                emailAprendiz = txtEmail.Text,
       
            };
            clFichaE oFicha = new clFichaE()
            {
                idFicha = int.Parse( ddlFicha.SelectedValue)
            };

            bool registroExitoso = registroAprendizLogica.RegistrarAprendiz(oAprendiz,oFicha);

            if (registroExitoso)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire('Registrado correctamente!');", true);
                LimpiarFormulario();
                Response.Redirect(Request.RawUrl);
                pnlAlert.Visible = true;
                pnlAlert.GroupingText = "Registro Exitoso!!!";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire({\r\n  icon: \"error\",\r\n  title: \"Oops...\",\r\n  text: \"No se registro el aprendiz\",\r\n});\r\n", true);


            }
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire({\r\n  icon: \"error\",\r\n  title: \"Oops...\",\r\n  text: \"Error al cargar las fichas\",\r\n});\r\n", true);

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
    }
}
