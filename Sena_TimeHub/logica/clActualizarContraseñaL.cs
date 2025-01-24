using Sena_TimeHub.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clActualizarContraseñaL
    {
        public bool mtdActualizarC (string contra,int idU)
        {
            clActualizarContraseña oAct = new clActualizarContraseña();
            return oAct.mtdActualizarC(contra,idU); 
        }
    }
}