
using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using Sena_TimeHub.logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Sena_TimeHub.vista
{
    public partial class VerAprendiz : System.Web.UI.Page
    {
        private static clHorarioAprendiz horarioL = new clHorarioAprendiz();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static List<object> ObtenerFechas()
        {
            if (HttpContext.Current.Session["idAprendiz"] == null)
            {
                return new List<object>(); 
            }

            int idApren;
            if (!int.TryParse(HttpContext.Current.Session["idAprendiz"].ToString(), out idApren))
            {
                return new List<object>(); 
            }

            List<clHorario> horarios = horarioL.mtdHorarioAprendiz(idApren);

            if (horarios == null || horarios.Count == 0)
            {
                return new List<object>(); 
            }

            var resultado = horarios.Select(h => new
            {
                fecha = h.fechaInicio.ToString("yyyy-MM-dd"),
                horaInicio = h.horaInicio.ToString(@"hh\:mm"), // Manejo de TimeSpan asegurado
                horaFin = h.horaFinal.ToString(@"hh\:mm"),
                area = h.nombreMateria,
                tipoArea=h.tipoMateria,
                ficha = h.ficha,
                ambiente = h.ambiente,
                dias = h.dias != null ? string.Join(", ", h.dias) : "", // Convertir lista a string
                instructor = h.instructor,
                idHorario = h.idHorario,
                esCancelada = h.esCancelada
            }).ToList();

            return resultado.Cast<object>().ToList();
        }

    }
}
