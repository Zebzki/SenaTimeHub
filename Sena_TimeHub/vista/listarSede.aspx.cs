using Sena_TimeHub.entidades;
using Sena_TimeHub.logica;
using Sena_TimeHub.logica.eliminar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sena_TimeHub.vista
{
    public partial class listarSede : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                cargarSede();
            }
        }
        private void cargarSede()
        {
            clObtenerSedeL oLogica = new clObtenerSedeL();
            List<clSedeE> listaC = oLogica.obtenerSede();
            gvSede.DataSource = listaC;
            gvSede.DataBind();
        }


        protected void gvSede_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string comando = e.CommandName;
            int id = Convert.ToInt32(e.CommandArgument);
            if (comando == "Editar")
            {
                editarSede(id);
            }
            
        }
       
        private void editarSede(int id)
        {
            Response.Redirect($"editarSede.aspx?idSede={id}");
        }

        protected void gvPrograma_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSede.PageIndex = e.NewPageIndex;
            BindGrid(); 
        }

        private void BindGrid()
        {
            clObtenerSedeL oLogica = new clObtenerSedeL();
            List<clSedeE> listaC = oLogica.obtenerSede();
            gvSede.DataSource = listaC;
            gvSede.DataBind();
        }

        protected void ExportToExcel()
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Programas.xls");
            Response.ContentType = "application/vnd.ms-excel";

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            gvSede.AllowPaging = false;
            BindGrid(); 

            gvSede.RenderControl(hw);

            Response.Write(sw.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // Se requiere para que el GridView se pueda renderizar en la exportación
        }

    }
}