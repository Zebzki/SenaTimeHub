using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clEditarHorarioL
    {

        clEditarHorarioD horarioData = new clEditarHorarioD();

        public bool EditarHorario(clHorario horario)
        {
            clEditarHorarioD datos = new clEditarHorarioD();
            return datos.EditarHorario(horario);
        }

        public Dictionary<string, object> ObtenerHorarioPorId(int idHorario)
        {
            return horarioData.ObtenerHorarioPorId(idHorario);
        }

        public clHorario ObtenerHorario(int idHorario)
        {
            clEditarHorarioD datos = new clEditarHorarioD();
            return datos.ObtenerHorario(idHorario);
        }

    }
}