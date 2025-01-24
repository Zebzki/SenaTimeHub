using Sena_TimeHub.entidades;
using Sena_TimeHub.logica;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sena_TimeHub.vista
{
    public partial class recuperarContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {







        }


        protected void btnEnviarCorreo_Click1(object sender, EventArgs e)
        {

            string correo = txtParametros.Text;

            clRecuperarContrasenaL objRC = new clRecuperarContrasenaL();


            clUsuarioE objDatosRecibidos = objRC.mtdRecuperarContrasena(correo, 0, null);

            if (objDatosRecibidos.validar == true)
            {

                string nombreCompleto = objDatosRecibidos.nombre + " " + objDatosRecibidos.apellido;
                Session["idUsuario"] = objDatosRecibidos.idUsuario.ToString();

                Random codigo4Digitos = new Random();
                int codigo = codigo4Digitos.Next(1000, 10000);
                txtCodigo.Value = codigo.ToString();
                clEnviarCorreoL objEnviarCodigo = new clEnviarCorreoL();

                string asunto = "Recuperacion de contraseña, (Equipo de cuentas)";
                string cuerpo = "Hola," + " " + nombreCompleto + " " + "Ingresa el codigo " + " *" + codigo + "* " + " en la plataforma para actualizar tu contraseña y entrar a tu cuenta";



                bool validacion = objEnviarCodigo.enviarCorreo(objDatosRecibidos.email, nombreCompleto, asunto, cuerpo);
                if (validacion == true)
                {

                    string script = "alert('Codigo enviado correctamente');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script, true);


                    txtParametros.Attributes["placeholder"] = "";
                    txtParametros.Text = "";
                    txtParametros.TextMode = TextBoxMode.SingleLine;
                    btnEnviarCorreo.Visible = false;
                    txtMensajePrincipal.InnerHtml = "Ingresa el codigo de cuatro dijitos enviado a (<b>" + objDatosRecibidos.email + "</b>).";
                    txtMensaje2.Visible = false;
                    btnVerificarCodigo.Visible = true;

                }
                else
                {

                    string script = "alert('Hubo un error al enviar el correo, comprueba tu direccion de correo');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script, true);
                    txtCodigo.Value = "";

                }

            }
            else
            {

                string script = "alert('El usuario " + correo + " no existe');";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script, true);

            }



        }

        protected void btnVerificarCodigo_Click(object sender, EventArgs e)
        {

            string codigoRecibido = txtParametros.Text;
            if (txtCodigo.Value == txtParametros.Text)
            {

                string script = "alert('Codigo correcto.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script, true);

                txtMensaje3.InnerText = "Ingresa tu nueva contraseña";
                string Modal = @"
                    var myModal = new bootstrap.Modal(document.getElementById('actualizarClave'));
                    myModal.show();

                ";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenModal", Modal, true);

            }
            else
            {


                string script = "alert('Codigo incorrecto.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script, true);


            }



        }

        protected void btnActualizarC_ServerClick(object sender, EventArgs e)
        {
            string contrasenaIngresada = txtContrasena.Text;

            if (contrasenaIngresada.Length < 9)
            {

                clRecuperarContrasenaL objRP = new clRecuperarContrasenaL();

                if (contrasenaIngresada.Length == 0)
                {

                    txtMensaje3.Attributes["style"] = "color: darkred;";
                    txtMensaje3.InnerText = "la contraseña no puede estar vacia";

                }
                else
                {


                    int idUsuario = int.Parse(Session["idUsuario"].ToString());
                    clUsuarioE objUsuarioValidacion = objRP.mtdRecuperarContrasena(null, idUsuario, txtContrasena.Text);

                    if (objUsuarioValidacion.validar == true)
                    {
                        Session.Clear();
                        Session.Abandon();

                        string alerta = "alert('Has actualizado tu contraseña correctamente, Inicia Sesion!!!');" +
                            "window.location='../index.aspx';";
                        ClientScript.RegisterStartupScript(this.GetType(), "alertRedirect", alerta, true);


                    }
                    else
                    {
                        string script = "alert('Ocurrio un error al actualizar tu contraseña, Intenta nuevamente');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script, true);

                    }


                }

            }
            else
            {

                txtMensaje3.Attributes["style"] = "color: darkred;";
                txtMensaje3.InnerText = "la contraseña no puede ser de mas de 8 caracteres";


            }
        }
    }
}
