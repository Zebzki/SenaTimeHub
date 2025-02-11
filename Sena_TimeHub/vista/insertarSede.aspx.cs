using Sena_TimeHub.entidades;
using Sena_TimeHub.logica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sena_TimeHub.vista
{
    public partial class insertarSede : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }


        protected void btnRegistrarSede_Click(object sender, EventArgs e)
        {


            try
            {


                string nombreSede = txtSede.Text;

                clRegistrarSedeL objSedeL = new clRegistrarSedeL();
                objSedeL.RegistrarSede(nombreSede);

                if (objSedeL != null)
                {

                    pnlAlert.Visible = true;
                    pnlAlert.GroupingText = "Registro Exitoso!!!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire('Registrado correctamente!');", true);
                    ClearFields();


                }
            }

            catch (Exception ex)
            {
                lblMensage.Text = "Error al cargar el nombre de la sede!!!" + ex;
      }
}
            

        
        private void ClearFields()
        {
            txtSede.Text = string.Empty;
        }
    }
}
