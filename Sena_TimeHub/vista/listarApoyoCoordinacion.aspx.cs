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
    public partial class listarApoyoCoordinacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCoordinacion();
            }
        }
        private void cargarCoordinacion()
        {
            int idRol = 4;
            clListarCoordinacionL oLogica = new clListarCoordinacionL();
            List<clUsuarioE> listaC = oLogica.mtdListarC(idRol);
            gvAC.DataSource = listaC;
            gvAC.DataBind();
        }

        protected void gvAC_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string comando = e.CommandName;
            int id = Convert.ToInt32(e.CommandArgument);
            if (comando == "Editar")
            {
                editarCoordinacion(id);
            }else if (comando == "Eliminar")
            {
                eliminarCoordinacion(id);
            }
        }
        private void editarCoordinacion(int id)
        {
            Response.Redirect($"editarApoyoCoordinacion.aspx?idUsuario={id}");
        }
        private void eliminarCoordinacion(int id)
        {
            clEliminarCoordinacionL oLogica = new clEliminarCoordinacionL();
            bool Eliminar = oLogica.mtdEliminacionC(id);
            if (Eliminar)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire('Personal de Coordinacion eliminado correctamente.');", true);
                
                cargarCoordinacion();
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire({\r\n  icon: \"error\",\r\n  title: \"Oops...\",\r\n  text: \"No se pudo eliminar \",\r\n});\r\n", true);

            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // Se requiere para que el GridView se pueda renderizar en la exportación
        }

    }
}