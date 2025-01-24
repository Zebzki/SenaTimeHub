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
            int idUsuario = Convert.ToInt32(Session["idUsuario"]);
            if (nuevaC != confirmarC)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "No coinciden las 2 contraseñas, revise porfavor";
            }
            bool exito = oActualizar.mtdActualizarC(nuevaC,idUsuario);
            if (exito)
            {
                lblMessage.ForeColor = System.Drawing.Color.Aqua;
                lblMessage.Text = "Contraseña Actualizada correctamente";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "error al actualizar la contraseña";
            }
        }
    }
}