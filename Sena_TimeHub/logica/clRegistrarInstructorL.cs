using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clRegistrarInstructorL
    {
        public bool mtdRegistarI (clUsuarioE oU, clArea oA)
        {
            clRegistrarInstructorD oRegistro = new clRegistrarInstructorD ();
            return oRegistro.mtdRegistroInstructor (oU, oA);    
        }
        public List<clArea> mtdObtenerArea()
        {
            clRegistrarInstructorD oInstru = new clRegistrarInstructorD ();
            return oInstru.mtdObtenerArea();
        }
    }
}