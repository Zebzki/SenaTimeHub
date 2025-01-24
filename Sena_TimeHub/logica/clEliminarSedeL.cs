using Sena_TimeHub.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clEliminarSedeL
    {
        public bool mtdEliminarSede(int id)
        {
            clEliminarSedeD oS = new clEliminarSedeD();
            return oS.mtdEliminarSede(id);
        }
    }
}