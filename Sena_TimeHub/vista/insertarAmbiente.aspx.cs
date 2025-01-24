using Sena_TimeHub.entidades;
using Sena_TimeHub.logica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sena_TimeHub.vista
{
    public partial class insertarAmbiente : System.Web.UI.Page
    {

        private readonly clObtenerSedeL sede = new clObtenerSedeL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSedes();
                pnlAlert.Visible = false;
            }
        }

        private void CargarSedes()
        {
            List<clSedeE> sedes = sede.obtenerSede();
            ddlSede.DataSource = sedes;
            ddlSede.DataTextField = "nombreSede";
            ddlSede.DataValueField = "nombreSede";
            ddlSede.DataBind();


            ddlSede.Items.Insert(0, new ListItem("Seleccione una Sede", ""));
        }
        protected void btnRegistrarAmbiente_Click(object sender, EventArgs e)
        {

            if (fuImagen.HasFile)
            {
                try
                {
                    string fileExtension = System.IO.Path.GetExtension(fuImagen.FileName).ToLower();
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

                    if (Array.Exists(allowedExtensions, ext => ext == fileExtension))
                    {
                        string folderPath = Server.MapPath("~/vista/images/");
                        if (!System.IO.Directory.Exists(folderPath))
                        {
                            System.IO.Directory.CreateDirectory(folderPath);
                        }

                        string fileName = fuImagen.FileName;
                        string filePath = folderPath + fileName;
                        fuImagen.SaveAs(filePath);

                        string imageUrl = "images/" + fuImagen.FileName;

                        string imagenAmbiente = imageUrl;

                        string nombreAmbiente = txtAmbiente.Text;
                        string nombreSede = ddlSede.SelectedValue;

                        clRegistrarAmbienteL objAmbineteLo = new clRegistrarAmbienteL();
                        objAmbineteLo.RegistrarAmbiente(nombreAmbiente, nombreSede, imagenAmbiente);

                        if (objAmbineteLo != null)
                        {

                            pnlAlert.Visible = true;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "Swal.fire('Registrado correctamente!');", true);
                            ClearFields();


                        }
                    }
                    else
                    {
                        lblMessage.Text = "Solo se permiten imágenes en formato JPG, JPEG, PNG o GIF.";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error al cargar la imagen: " + ex.Message;
                }
            }
            else
            {
                lblMessage.Text = "Por favor selecciona un archivo.";
            }

        }
        private void ClearFields()
        {
            txtAmbiente.Text = string.Empty;
            //txtImagen. = string.Empty;
            //txtCodigo.Text = string.Empty;
            //ddlTipo.SelectedValue = string.Empty;
        }
    }

}