using Sena_TimeHub.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clEliminarHorarioL
    {
        public bool mtdEliminarHorario(int idHorario)
        {
            clEliminarHorario oE = new clEliminarHorario();
            return oE.mtdEliminarHorario(idHorario);
        }
    }
}