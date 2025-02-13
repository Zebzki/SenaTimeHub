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
        public clAprendizE mtdRecuperarContrasenaAp(string correo = null, int idAprendiz = 0, string contrasena = null)
        {
            clAprendizE objAprendiz = new clAprendizE();
            clRecuperarConstrasenaD objApD = new clRecuperarConstrasenaD();

            if (correo != null)
            {


                objAprendiz = objApD.mtdRecuperarContrasenaAp(correo, 0, null);


            }
            else
            {

                objAprendiz = objApD.mtdRecuperarContrasenaAp(null, idAprendiz, contrasena);

            }


            return objAprendiz;



        }


    }
}