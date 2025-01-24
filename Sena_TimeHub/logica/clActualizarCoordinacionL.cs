using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clActualizarCoordinacionL
    {
        public bool mtdActualizarC (clUsuarioE oU)
        {
            clActualizarCoordinacionD oAct = new clActualizarCoordinacionD ();
            return oAct.mtdActualizarC (oU);    
        }
    }
}