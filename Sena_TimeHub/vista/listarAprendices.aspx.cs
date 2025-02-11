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
                CargarFichas();
                pnlAprendices.Visible = false;
                pnlEditarAprendiz.Visible = false;
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
            Console.WriteLine("Id: " + id);

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
            Response.Redirect($"editarAprendiz.aspx?idAprendiz={id}");
        }

        private void eliminarAprendiz(int id)
        {
            try
            {
                bool eliminado = eliminar.mtdEliminarAprendiz(id);

                if (eliminado)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire('El aprendiz fue eliminado correctamente.');", true);
                    cargarAprendices(int.Parse(hfSelectedFicha.Value));
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire({\r\n  icon: \"error\",\r\n  title: \"Oops...\",\r\n  text: \"No se eliminó\",\r\n});\r\n", true);

                }
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
