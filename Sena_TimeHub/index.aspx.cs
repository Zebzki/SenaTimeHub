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
    public partial class index1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void mensaje (string msj)
        {
            string script = "alert('" + msj + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", script, true);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                mensaje("ingrese su usuario(Email)");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                mensaje("ingrese su contraseña");
                return;
            }
            clUsuarioE oUsuario = new clUsuarioE();
            oUsuario.email = txtEmail.Text;
            oUsuario.contraseña = txtPassword.Text;

            clAprendizE oAprendiz = new clAprendizE();
            oAprendiz.emailAprendiz = txtEmail.Text;
            oAprendiz.contrasenaAprendiz = txtPassword.Text;

            clAprendizL oLogicaA = new clAprendizL();
            clAprendizE oIngresoAprendiz = oLogicaA.mtdIngresoAprendiz(oAprendiz);

            clUsuarioL oLogica = new clUsuarioL();
            clUsuarioE oIngreso = oLogica.mtdIngresar(oUsuario);
            if (oIngreso !=null)
            {
                Session["idUsuario"] = oIngreso.idUsuario;
                Session["usuario"] = oIngreso.nombre+" "+oIngreso.apellido;
                Session["tipoUsuario"] = "usuario";
                if (!string.IsNullOrEmpty(oIngreso.rol))
                {
                   
                Session["rol"] = oIngreso.rol;

                }
               
                if (oIngreso.rol == "Instructor")
                {
                    Response.Redirect("vista/dashboardInstructor.aspx");
                    return;
                }

                Response.Redirect("vista/dashboard.aspx");
                
            }
            else
            {
                mensaje("usuario o contraseña incorrectos");

            }
            if (oIngresoAprendiz !=null )
            {
                Session["idAprendiz"] = oIngresoAprendiz.idAprendiz;
                Session["aprendiz"] = oIngresoAprendiz.nombreAprendiz + " " + oIngresoAprendiz.apellidoAprendiz;
                Session["tipoUsuario"] = "aprendiz";
                Response.Redirect("vista/dashboardAprendiz.aspx");        
            }
            else
            {
                mensaje("usuario o contraseña incorrectos");

            }
        }
    }
}