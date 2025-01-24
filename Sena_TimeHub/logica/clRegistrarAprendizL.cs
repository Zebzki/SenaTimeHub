using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;

namespace Sena_TimeHub.logica
{
    public class clRegistarAprendizL
    {
        private clRegistarAprendizD RegistroAprendiz = new clRegistarAprendizD();


        public bool RegistrarAprendiz(clUsuarioE oU, clFichaE oF)
        {
            return RegistroAprendiz.RegistrarAprendiz(oU, oF);
        }


        public List<clFichaE> ObtenerFichas()
        {
            return RegistroAprendiz.ObtenerFichas();
        }
    }
}
