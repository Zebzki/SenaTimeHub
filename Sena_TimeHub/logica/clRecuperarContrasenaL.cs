using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clRecuperarContrasenaL
    {

        public clUsuarioE mtdRecuperarContrasena(string correo = null, int idUsuario = 0, string contrasena = null)
        {
            clUsuarioE objUsuarioE = new clUsuarioE();
            clRecuperarConstrasenaD objUsuarioD = new clRecuperarConstrasenaD();

            if (correo != null)
            {


                objUsuarioE = objUsuarioD.mtdRecuperarContrasena(correo, 0, null);


            }
            else
            {

                objUsuarioE = objUsuarioD.mtdRecuperarContrasena(null, idUsuario, contrasena);

            }


            return objUsuarioE;



        }


    }
}