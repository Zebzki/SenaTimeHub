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
    public partial class insertarHorario : System.Web.UI.Page
    {
        clFichaL fichaLogica = new clFichaL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CargarProgramas();


            }
        }

        private void CargarProgramas()
        {
            List<clProgramaE> programas = fichaLogica.ObtenerProgramas();
            ddlPrograma.DataSource = programas;
            ddlPrograma.DataTextField = "nombrePrograma";
            ddlPrograma.DataValueField = "nombrePrograma";
            ddlPrograma.DataBind();

            ddlPrograma.Items.Insert(0, new ListItem("Seleccione un programa", ""));
        }
    }
}