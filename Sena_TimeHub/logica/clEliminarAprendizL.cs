using Sena_TimeHub.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clEliminarAprendizL
    {
        public bool mtdEliminarAprendiz(int idAprendiz)
        {
            clEliminarAprendices oE = new clEliminarAprendices();
            return oE.mtdEliminarAprendices(idAprendiz);
        }
    }
}