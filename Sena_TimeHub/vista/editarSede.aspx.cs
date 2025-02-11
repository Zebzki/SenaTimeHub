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
    public partial class editarSede : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idURL = Request.QueryString["idSede"];
                if (!string.IsNullOrWhiteSpace(idURL))
                {
                    int id = int.Parse(idURL);
                    cargarSede(id);
                }
            }
        }
        private void cargarSede(int id)
        {

            clObtenerSedeL oLogica = new clObtenerSedeL();
            clSedeE oSede = oLogica.mtdObtenerSede(id);
            if (oSede != null)
            {
                txtNombre.Text = oSede.nombreSede;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire({\r\n  icon: \"error\",\r\n  title: \"Oops...\",\r\n  text: \"No se cargo el Instructor\",\r\n});\r\n", true);
            }

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            clActualizarSedeL Ologica = new clActualizarSedeL();
            clSedeE oSede = new clSedeE()
            {

                idSede = int.Parse(Request.QueryString["idSede"]),
                nombreSede = string.IsNullOrWhiteSpace(txtNombre.Text) ? null : txtNombre.Text
            };
            
            bool exito = Ologica.mtdEditarSede(oSede);
            if (exito)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert",
          "Swal.fire({ title: 'Se actualizó correctamente', icon: 'success' }).then(() => { window.location.href = 'listarSede.aspx'; });", true);

                Response.Redirect("listarSede.aspx");

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire({ icon: 'error',  title: 'Oops...',  text: 'NO se puedo Actualizar'});", true);

            }
        }
    }
}