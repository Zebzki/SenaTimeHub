using Sena_TimeHub.entidades;
using Sena_TimeHub.logica;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sena_TimeHub.vista
{
    public partial class editarHorario : System.Web.UI.Page
    {
       
            private clEditarHorarioL horarioLogica = new clEditarHorarioL();


        private clInsertarHorarioL logicaHorario;
        protected void Page_Load(object sender, EventArgs e)
            {
            logicaHorario = new clInsertarHorarioL();
            if (!IsPostBack)
                {

                CargarDisponibilidad();
                    // Obtener el ID del horario a editar desde la URL
                    int idHorario;
                    if (Request.QueryString["idHorario"] != null && int.TryParse(Request.QueryString["idHorario"], out idHorario))
                    {
                        CargarDatosHorario(idHorario);
                    }
                    else
                    {
                        lblMensaje.Text = "Error: No se ha seleccionado un horario válido.";
                        lblMensaje.CssClass = "alert alert-danger text-center d-block";
                    }
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


        private void CargarDatosHorario(int idHorario)
            {
            clHorario horario = horarioLogica.ObtenerHorario(idHorario);

            if (horario != null)
                {
                    ddlInstructor.SelectedValue = horario.idUsuario.ToString();
                    ddlFicha.SelectedValue = horario.idFicha.ToString();
                    ddlAmbiente.SelectedValue = horario.idAmbiente.ToString();

                    txtFechaInicio.Text = horario.fechaInicio.ToString("yyyy-MM-dd");
                    txtFechaFinal.Text = horario.fechaFinal.ToString("yyyy-MM-dd");
                    txtHoraInicio.Text = horario.horaInicio.ToString(@"hh\:mm");
                    txtHoraFinal.Text = horario.horaFinal.ToString(@"hh\:mm");

                    // Cargar los días de la semana
                    chkLunes.Checked = horario.dias.Contains("lunes");
                    chkMartes.Checked = horario.dias.Contains("martes");
                    chkMiercoles.Checked = horario.dias.Contains("miércoles");
                    chkJueves.Checked = horario.dias.Contains("jueves");
                    chkViernes.Checked = horario.dias.Contains("viernes");
                    chkSabado.Checked = horario.dias.Contains("sabado");
                }
                else
                {
                    lblMensaje.Text = "No se encontraron datos para el horario seleccionado.";
                    lblMensaje.CssClass = "alert alert-warning text-center d-block";
                }
            }

            protected void btnActualizar_Click(object sender, EventArgs e)
            {
                int idHorario;
                if (Request.QueryString["idHorario"] != null && int.TryParse(Request.QueryString["idHorario"], out idHorario))
                {
                    clHorario horario = new clHorario
                    {
                        idHorario = idHorario,
                        idUsuario = int.Parse(ddlInstructor.SelectedValue),
                        idFicha = int.Parse(ddlFicha.SelectedValue),
                        idAmbiente = int.Parse(ddlAmbiente.SelectedValue),
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

                clEditarHorarioL horarioE = new clEditarHorarioL();
                    bool actualizado = horarioE.EditarHorario(horario);

                    if (actualizado)
                    {
                        lblMensaje.Text = "Horario actualizado correctamente.";
                        lblMensaje.CssClass = "alert alert-success text-center d-block";
                    Response.Redirect("listarHorario.aspx");
                    }
                    else
                    {
                        lblMensaje.Text = "Error al actualizar el horario.";
                        lblMensaje.CssClass = "alert alert-danger text-center d-block";
                    }
                }
                else
                {
                    lblMensaje.Text = "Error: No se encontró un horario válido para actualizar.";
                    lblMensaje.CssClass = "alert alert-danger text-center d-block";
                }
            }

        private string ObtenerDiasSeleccionados()
        {
            List<string> diasSeleccionados = new List<string>();

            if (chkLunes.Checked) diasSeleccionados.Add("Lunes");
            if (chkMartes.Checked) diasSeleccionados.Add("Martes");
            if (chkMiercoles.Checked) diasSeleccionados.Add("Miércoles");
            if (chkJueves.Checked) diasSeleccionados.Add("Jueves");
            if (chkViernes.Checked) diasSeleccionados.Add("Viernes");
            if (chkSabado.Checked) diasSeleccionados.Add("Sábado");

            return string.Join(",", diasSeleccionados);
        }
    }
    }

