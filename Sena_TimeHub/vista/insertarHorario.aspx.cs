using System;
using System.Web.UI;
using Sena_TimeHub.entidades;
using Sena_TimeHub.logica;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Sena_TimeHub.vista
{
    public partial class insertarHorario : Page
    {
        private clInsertarHorarioL logicaHorario;

        protected void Page_Load(object sender, EventArgs e)
        {
            logicaHorario = new clInsertarHorarioL();

            if (!IsPostBack)
            {
                CargarDisponibilidad();
            }
        }

        private void CargarDisponibilidad()
        {
            try
            {
                Dictionary<string, List<object>> disponibilidad = logicaHorario.ObtenerDisponibilidad();

                if (disponibilidad != null && disponibilidad.Count > 0)
                {
                    if (disponibilidad.ContainsKey("Instructores"))
                    {
                        ddlInstructor.DataSource = disponibilidad["Instructores"];
                        ddlInstructor.DataTextField = "NombreInstructor";
                        ddlInstructor.DataValueField = "IdInstructor";
                        ddlInstructor.DataBind();
                    }
                    ddlInstructor.Items.Insert(0, new ListItem("Seleccione un Instructor", "0"));

                    if (disponibilidad.ContainsKey("Fichas"))
                    {
                        ddlFicha.DataSource = disponibilidad["Fichas"];
                        ddlFicha.DataTextField = "NumeroFicha";
                        ddlFicha.DataValueField = "IdFicha";
                        ddlFicha.DataBind();
                    }
                    ddlFicha.Items.Insert(0, new ListItem("Seleccione una Ficha", "0"));

                    if (disponibilidad.ContainsKey("Ambientes"))
                    {
                        ddlAmbiente.DataSource = disponibilidad["Ambientes"];
                        ddlAmbiente.DataTextField = "NombreAmbiente";
                        ddlAmbiente.DataValueField = "IdAmbiente";
                        ddlAmbiente.DataBind();
                    }
                    ddlAmbiente.Items.Insert(0, new ListItem("Seleccione un Ambiente", "0"));

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", $"alert('Error al cargar disponibilidad: {ex.Message}');", true);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlInstructor.SelectedValue == "0" || ddlFicha.SelectedValue == "0" || ddlAmbiente.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alerta", "alert('Debe seleccionar Instructor, Ficha y Ambiente.');", true);
                    return;
                }

                if (string.IsNullOrEmpty(txtFechaInicio.Text) || string.IsNullOrEmpty(txtFechaFinal.Text) ||
                    string.IsNullOrEmpty(txtHoraInicio.Text) || string.IsNullOrEmpty(txtHoraFinal.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alerta", "alert('Debe completar todas las fechas y horas.');", true);
                    return;
                }

                clHorario nuevoHorario = new clHorario
                {
                    IdInstructor = Convert.ToInt32(ddlInstructor.SelectedValue),
                    IdFicha = Convert.ToInt32(ddlFicha.SelectedValue),
                    IdAmbiente = Convert.ToInt32(ddlAmbiente.SelectedValue),
                    fechaInicio = DateTime.Parse(txtFechaInicio.Text),
                    fechaFinal = DateTime.Parse(txtFechaFinal.Text),
                    horaInicio = TimeSpan.Parse(txtHoraInicio.Text),
                    horaFinal = TimeSpan.Parse(txtHoraFinal.Text),
                    lunes = chkLunes.Checked,
                    martes = chkMartes.Checked,
                    miercoles = chkMiercoles.Checked,
                    jueves = chkJueves.Checked,
                    viernes = chkViernes.Checked,
                    sabado = chkSabado.Checked
                };

                string resultado = logicaHorario.RegistrarHorario(nuevoHorario);

                ScriptManager.RegisterStartupScript(this, GetType(), "alerta", $"alert('{resultado}'); ", true);
            }
            catch (FormatException)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alerta", "alert('Formato incorrecto en fechas u horas.');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alerta", $"alert('Error al registrar el horario: {ex.Message}');", true);
            }
        }
    }
}
