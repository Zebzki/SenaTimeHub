using Sena_TimeHub.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clEliminarCoordinacionL
    {
        public bool mtdEliminacionC(int id)
        {
            clEliminarCoordinacionD oE = new clEliminarCoordinacionD();
            return oE.mtdEliminacionC(id);
        }
    }
}