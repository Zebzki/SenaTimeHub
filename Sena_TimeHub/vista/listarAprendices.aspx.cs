using System;
using Sena_TimeHub.logica;
using Sena_TimeHub.entidades;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Sena_TimeHub.vista
{
    public partial class listarAprendices : System.Web.UI.Page
    {
        private clListarAprendicesL logica = new clListarAprendicesL();
        private clEditarAprendizL editar = new clEditarAprendizL();
        private clEliminarAprendizL eliminar = new clEliminarAprendizL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate, private";
                Response.Headers["Pragma"] = "no-cache";
                Response.Headers["Expires"] = "0";

                CargarFichas();
                pnlAprendices.Visible = false;
                pnlEditarAprendiz.Visible = false;


                if (Session["Eliminado"] != null && (bool)Session["Eliminado"])
                {
                    MostrarAlerta("El aprendiz fue eliminado correctamente.");
                    Session["Eliminado"] = null;
                }
                else if (Session["Eliminado"] != null && !(bool)Session["Eliminado"])
                {
                    MostrarAlerta("No se eliminó el aprendiz.");
                    Session["Eliminado"] = null;
                }
            }
        }

        private void CargarFichas()
        {
            try
            {
                repFichas.DataSource = logica.ObtenerFichas();
                repFichas.DataBind();
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cargar las fichas: {ex.Message}");
            }
        }

        private void MostrarError(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", $"alert('{mensaje}');", true);
        }

        private void MostrarAlerta(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", $"Swal.fire('{mensaje}');", true);
        }

        protected void repFichas_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                try
                {
                    int idFicha = Convert.ToInt32(e.CommandArgument);
                    pnlAprendices.Visible = true;
                    cargarAprendices(idFicha);
                }
                catch (Exception ex)
                {
                    MostrarError($"Error al seleccionar ficha: {ex.Message}");
                }
            }
        }

        private void cargarAprendices(int idFicha)
        {
            try
            {
                gvAprendices.DataSource = logica.ObtenerAprendicesPorFicha(idFicha);
                gvAprendices.DataBind();
                hfSelectedFicha.Value = idFicha.ToString();
            }
            catch (Exception ex)
            {
                MostrarError($"Error al cargar aprendices: {ex.Message}");
            }
        }

        protected void gvAprendices_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                editarAprendiz(id);
            }
            else if (e.CommandName == "CustomDelete")
            {
                eliminarAprendiz(id);
            }
        }

        private void editarAprendiz(int id)
        {
            Response.Redirect($"editarAprendiz.aspx?idUsuario={id}");
        }

        private void eliminarAprendiz(int id)
        {
            try
            {
                bool eliminado = eliminar.mtdEliminarAprendiz(id);

                if (eliminado)
                {

                    Session["Eliminado"] = true;
                }
                else
                {

                    Session["Eliminado"] = false;
                }


                cargarAprendices(int.Parse(hfSelectedFicha.Value));


                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                MostrarError($"Error al eliminar el aprendiz: {ex.Message}");
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            // Se requiere para que el GridView se pueda renderizar en la exportación
        }
    }
}
