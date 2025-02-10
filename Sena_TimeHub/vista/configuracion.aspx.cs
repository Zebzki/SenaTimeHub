using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sena_TimeHub.logica;

namespace Sena_TimeHub.vista
{
    public partial class configuracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            clActualizarContraseñaL oActualizar = new clActualizarContraseñaL();

            string nuevaC = txtNewPassword.Text;
            string confirmarC = txtConfirmPassword.Text;

            // Validar que las contraseñas coincidan
            if (nuevaC != confirmarC)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Las contraseñas no coinciden, revise por favor";
                return; // Evita seguir con la ejecución
            }

            int? idUsuario = Session["idUsuario"] as int?;
            int? idAprendiz = Session["idAprendiz"] as int?;

            bool exito = false;

            if (idUsuario.HasValue)
            {
                exito = oActualizar.mtdActualizarCU(nuevaC, idUsuario.Value);
            }
            else if (idAprendiz.HasValue)
            {
                exito = oActualizar.mtdActualizarCA(nuevaC, idAprendiz.Value);
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error: No se encontró un usuario o aprendiz válido.";
                return;
            }

            // Mensaje de éxito o error
            if (exito)
            {
                lblMessage.ForeColor = System.Drawing.Color.Aqua;
                lblMessage.Text = "Contraseña actualizada correctamente";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error al actualizar la contraseña";
            }


        }
    }
}
