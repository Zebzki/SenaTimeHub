using Sena_TimeHub.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clActualizarContraseñaL
    {
        public bool mtdActualizarCU (string contra,int idU)
        {
            clActualizarContraseña oAct = new clActualizarContraseña();
            return oAct.mtdActualizarCU(contra,idU); 
        }
        public bool mtdActualizarCA(string contra, int idA)
        {
            clActualizarContraseña oAct = new clActualizarContraseña();
            return oAct.mtdActualizarCA(contra, idA);
        }
    }
}