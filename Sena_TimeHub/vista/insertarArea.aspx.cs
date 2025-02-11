using Sena_TimeHub.logica;
using System;

namespace Sena_TimeHub.vista
{
    public partial class insertarArea : System.Web.UI.Page
    {
        private readonly clRegistrarAreaL areaLogica = new clRegistrarAreaL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlAlert.Visible = false;
            }
        }

        protected void btnRegistrarArea_Click(object sender, EventArgs e)
        {
            string nombreArea = txtNombreArea.Text.Trim();
            string tipo = txtTipoArea.Text.Trim();

            if (!string.IsNullOrEmpty(nombreArea) || !string.IsNullOrEmpty(tipo))
            {
                try
                {
                    string mensaje = areaLogica.RegistrarArea(nombreArea, tipo);


                    pnlAlert.Visible = true;
                    litAlert.Text = mensaje;


                    ClearFields();
                }
                catch (Exception ex)
                {
                    pnlAlert.Visible = true;
                    litAlert.Text = "Ocurrió un error: " + ex.Message;
                }
            }
        }

        private void ClearFields()
        {
            txtNombreArea.Text = string.Empty;
        }
    }
}
