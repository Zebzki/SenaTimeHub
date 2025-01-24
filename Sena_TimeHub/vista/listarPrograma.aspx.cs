using Sena_TimeHub.entidades;
using Sena_TimeHub.logica;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sena_TimeHub.vista
{
    public partial class listarPrograma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarPrograma();
            }
        }
        private void cargarPrograma()
        {
            clListarProgramaL oLogica = new clListarProgramaL();
            List<clProgramaE> listaC = oLogica.mtdListarPrograma();
            gvPrograma.DataSource = listaC;
            gvPrograma.DataBind();
        }

        protected void gvPrograma_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }
       

        public override void VerifyRenderingInServerForm(Control control)
        {
            // Se requiere para que el GridView se pueda renderizar en la exportación
        }


    }
}
