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
                CargarProgramas();


            }
        }

        private void CargarProgramas()
        {
            List<clProgramaE> programas = fichaLogica.ObtenerProgramas();
            ddlPrograma.DataSource = programas;
            ddlPrograma.DataTextField = "nombrePrograma";
            ddlPrograma.DataValueField = "idPrograma";
            ddlPrograma.DataBind();

           
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

                DataTable usuarios = fichaLogica.CrearTablaUsuarios();
                if (fuUsuarios.HasFile)
                {
                    using (ExcelPackage package = new ExcelPackage(fuUsuarios.FileContent))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        int rows = worksheet.Dimension.Rows;
                        for (int i = 2; i <= rows; i++)
                        {
                            string nombre = worksheet.Cells[i, 1].Text;
                            string apellido = worksheet.Cells[i, 2].Text;
                            string tipoDocumento = worksheet.Cells[i, 3].Text;
                            string documento = worksheet.Cells[i, 4].Text;
                            string email = worksheet.Cells[i, 5].Text;
                            string contraseña = worksheet.Cells[i, 6].Text;
                            int idRol = 3;


                            usuarios.Rows.Add(nombre, apellido, tipoDocumento, documento, email, contraseña, idRol);
                        }
                    }
                }
                bool resultado = fichaLogica.RegistrarFichaYUsuarios(numeroFicha, fechaInicio, fechaFinal, jornada, idPrograma, usuarios);
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
                lblMensaje.Text = "error" + ex.Message;

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
