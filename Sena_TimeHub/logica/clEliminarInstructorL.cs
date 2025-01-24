using Sena_TimeHub.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica.eliminar
{
    public class clEliminarInstructorL
    {
        public bool mtdEliminarI (int id)
        {
            clEliminarInstructor oE = new clEliminarInstructor();   
            return oE.mtdEliminarI(id);
        }
    }
}