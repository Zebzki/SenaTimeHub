using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using Sena_TimeHub.logica;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sena_TimeHub.vista
{
    public partial class listarFicha_aspx : System.Web.UI.Page
    {
        clListarFichaL fichaLogica = new clListarFichaL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarFichas(0);
            }
        }

        private void CargarFichas(int pageIndex)
        {
            try
            {
                List<clFichaE> listaFichas = fichaLogica.mtdListarF(0);

                if (listaFichas != null && listaFichas.Count > 0)
                {
                    gvFichas.DataSource = listaFichas;
                    gvFichas.PageIndex = pageIndex;
                    gvFichas.DataBind();
                    lblPaginaActual.Text = (pageIndex + 1).ToString();
                }
                else
                {
                    gvFichas.DataSource = null;
                    gvFichas.DataBind();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire('No se encontraron fichas');", true);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire({\r\n  icon: \"error\",\r\n  title: \"Oops...\",\r\n  text: \"Error al cargar las fichas\",\r\n});\r\n"+ ex.Message, true);

            }
        }

        protected void gvFichas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFichas.PageIndex = e.NewPageIndex;
            CargarFichas(e.NewPageIndex);
        }
    }
}
