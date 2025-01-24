using Sena_TimeHub.entidades;
using Sena_TimeHub.datos;

namespace Sena_TimeHub.logica
{
    public class clUsuarioL
    {
        clUsuarioD objUsuarioD = new clUsuarioD();

        public clUsuarioE mtdIngresar(clUsuarioE oData)
        {
            return objUsuarioD.mtdIngreso(oData);
        }

        public clUsuarioE mtdRecuperarContrasena(string idUsuario = null, string correo = null, string contrasena = null)
        {
            return objUsuarioD.mtdRecuperarContrasena(idUsuario, correo, contrasena);
        }
    }
}
