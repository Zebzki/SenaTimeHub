using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica.editar
{
    public class clActualizarInstructorL
    {
        public bool mtdActI (clUsuarioE oData)
        {
            clActualizarInstructorD oA = new clActualizarInstructorD(); 
            return oA.mtdActI (oData);  
        }
    }
}