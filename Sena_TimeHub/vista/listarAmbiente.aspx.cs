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
    public partial class listarAmbiente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarAmbiente();
            }
        }
        private void cargarAmbiente()
        {
            clListarAmbienteL oLogica = new clListarAmbienteL();
            List<clAmbienteE> listaA = oLogica.mtdListarAmbiente();
            gvAmbiente.DataSource = listaA;
            gvAmbiente.DataBind();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            // Se requiere para que el GridView se pueda renderizar en la exportación
        }

        protected void gvAmbiente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }


    }
    }
