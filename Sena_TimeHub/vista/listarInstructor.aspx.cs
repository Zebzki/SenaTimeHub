using Sena_TimeHub.entidades;
using Sena_TimeHub.logica;
using Sena_TimeHub.logica.eliminar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sena_TimeHub.vista
{
    public partial class listarInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarInstructor();
            }
        }
        private void cargarInstructor()
        {
            int idrol = 2;
            clListarCoordinacionL oLista = new clListarCoordinacionL();
            List<clUsuarioE> Instructor = oLista.mtdListarC(idrol);
            gvInstructor.DataSource = Instructor;
            gvInstructor.DataBind();
        }


        protected void gvInstructor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string comando = e.CommandName;
            int id = Convert.ToInt32(e.CommandArgument);
            if (comando == "Editar")
            {
                editarI(id);
            }
            else if (comando == "Eliminar")
            {
                eliminarI(id);
            }
        }
        private void eliminarI(int id)
        {
            clEliminarInstructorL oEliminar = new clEliminarInstructorL();
            bool eliminado = oEliminar.mtdEliminarI(id);
            if (eliminado)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire('Instructor Eliminado!');", true);
                cargarInstructor();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire({\r\n  icon: \"error\",\r\n  title: \"Oops...\",\r\n  text: \"No se eliminó\",\r\n});\r\n", true);

            }
        }
        private void editarI(int id)
        {
            Response.Redirect($"editarInstructor.aspx?idUsuario={id}");
        }
    }
}