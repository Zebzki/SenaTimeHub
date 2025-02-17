using OfficeOpenXml;
using Sena_TimeHub.entidades;
using Sena_TimeHub.logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sena_TimeHub.vista
{
    public partial class insertarFicha : System.Web.UI.Page
    {
        private  clFichaL fichaLogica = new clFichaL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProgramasySede();


            }
        }

        private void CargarProgramasySede()
        {
            List<clProgramaE> programas = fichaLogica.ObtenerProgramas();
            ddlPrograma.DataSource = programas;
            ddlPrograma.DataTextField = "nombrePrograma";
            ddlPrograma.DataValueField = "idPrograma";
            ddlPrograma.DataBind();

            List<clSedeE> sedes = fichaLogica.obtenerSedes();
            ddlSede.DataSource = sedes;
            ddlSede.DataTextField = "nombreSede";
            ddlSede.DataValueField = "idSede";
            ddlSede.DataBind();

        }

        protected void btnGuardarFicha_Click(object sender, EventArgs e)
        {
            try
            {
                string numeroFicha = txtNumeroFicha.Text;
                DateTime fechaInicio = DateTime.Parse(txtFechaInicio.Text);
                DateTime fechaFinal = DateTime.Parse(txtFechaFinal.Text);
                string jornada = ddlJornadaFicha.SelectedValue;
                int idPrograma = int.Parse(ddlPrograma.SelectedValue);
                int idSede = int.Parse(ddlSede.SelectedValue);

                DataTable aprendices = fichaLogica.CrearTablaUsuarios();

                if (fuUsuarios.HasFile && fuUsuarios.PostedFile.ContentLength > 0)
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (ExcelPackage package = new ExcelPackage(fuUsuarios.FileContent))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        int rows = worksheet.Dimension.Rows;

                        int lastRow = worksheet.Dimension?.End.Row ?? 0;

                        System.Diagnostics.Debug.WriteLine("Número de filas en el archivo Excel: " + rows);
                        for (int i = 1; i <= lastRow; i++)
                        {
                            string nombre = worksheet.Cells[i, 1].Text.Trim();
                            string apellido = worksheet.Cells[i, 2].Text.Trim();
                            string tipoDocumento = worksheet.Cells[i, 3].Text.Trim();
                            string documento = worksheet.Cells[i, 4].Text.Trim();
                            string email = worksheet.Cells[i, 5].Text.Trim();
                            if (!string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrWhiteSpace(apellido) &&
                                                 !string.IsNullOrWhiteSpace(tipoDocumento) && !string.IsNullOrWhiteSpace(documento) &&
                                                 !string.IsNullOrWhiteSpace(email))
                            {


                                aprendices.Rows.Add(nombre, apellido, tipoDocumento, documento, email);

                                // Depuración: Verificar datos agregados
                                System.Diagnostics.Debug.WriteLine($"Fila agregada: Nombre = {nombre}, Apellido = {apellido}, Documento = {documento}, Email = {email}");
                            }
                            else
                            {
                                // Depuración: Indicar que se omitió una fila vacía
                                System.Diagnostics.Debug.WriteLine("Se omitió una fila vacía");
                            }

                        }

                        System.Diagnostics.Debug.WriteLine("Número de filas en el DataTable aprendices: " + aprendices.Rows.Count);
                    }

                }

                bool resultado = fichaLogica.RegistrarFichaYUsuarios(numeroFicha, fechaInicio, fechaFinal, jornada, idPrograma, idSede, aprendices);
                if (resultado)
                {
                    lblMensaje.Text = "Se registro correctamente";
                }
                else
                {
                    lblMensaje.Text = " NO se registro, error";

                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "error en cs" + ex.Message;

            }
            LimpiarCampos();

        }

        private void LimpiarCampos()
        {
            txtNumeroFicha.Text = "";
            ddlJornadaFicha.SelectedIndex = 0;
            ddlPrograma.SelectedIndex = 0;
            txtFechaInicio.Text = "";
            txtFechaFinal.Text = "";
        }
    }
}
