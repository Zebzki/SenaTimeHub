using System;
using System.Collections.Generic;

using System.Data;
using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using static Sena_TimeHub.logica.HorarioBLL;

namespace Sena_TimeHub.logica
{
    public class HorarioBLL
    {
        public class HorarioA
        {
            private clHorarioAprendiz horarioA = new clHorarioAprendiz();

            public List<clHorario> mtdHorarioAprendiz(int idAprendiz)
            {
                return horarioA.mtdHorarioAprendiz(idAprendiz);
            }
            public List<DateTime> mtdObtenerFechasCanceladas(int idAprendiz)
            {
                ; return horarioA.mtdObtenerFechasCanceladas(idAprendiz);
            }
        }
    }

}
