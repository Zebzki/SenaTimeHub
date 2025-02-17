using System;
using System.Web.UI;
using Sena_TimeHub.entidades;
using Sena_TimeHub.logica;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Serialization;
using Sena_TimeHub.datos;

namespace Sena_TimeHub.vista
{
    public partial class listarHorario : Page
    {

        clRegistarAprendizL registroAprendiz = new clRegistarAprendizL();
        clListarHorarioL oHorario = new clListarHorarioL();
        private clListarHorarioL horarioLogica = new clListarHorarioL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarFichas();
            }
        }


        protected void ddlFicha_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idFicha = Convert.ToInt32(ddlFicha.SelectedValue);
            List<clHorario> horarios = new clListarHorarioL().ObtenerHorarios(idFicha);
            rptHorarios.DataSource = horarios;
            rptHorarios.DataBind();
        }

        private void CargarFichas()
        {

           
            List<clFichaE> listarFichas = registroAprendiz.ObtenerFichas();

                ddlFicha.Items.Clear();
                ddlFicha.Items.Add(new ListItem("Seleccione ficha", ""));
            
                if (listarFichas != null && listarFichas.Count > 0)
                {
                    foreach (clFichaE ficha in listarFichas)
                    {
                        string texto = $"{ficha.numeroFicha} - {ficha.nombrePrograma}";
                        ddlFicha.Items.Add(new ListItem(texto, ficha.idFicha.ToString()));
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire({\r\n  icon: \"error\",\r\n  title: \"Oops...\",\r\n  text: \"Error al cargar las fichas\",\r\n});\r\n", true);

                }
    
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idHorario = Convert.ToInt32(btn.CommandArgument);

            Response.Redirect("editarHorario.aspx?idHorario=" + idHorario);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idHorario = Convert.ToInt32(btn.CommandArgument);

            clEliminarHorarioL logica = new clEliminarHorarioL();
            bool eliminado = logica.mtdEliminarHorario(idHorario);

            if (eliminado)
            {
                Response.Redirect("listarHorario.aspx");
            } else
            {
                Response.Redirect("listarHorario.aspx");
            }
        }

    }
}
