using Datos;
using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;

namespace Sena_TimeHub.logica
{
    public class clInsertarHorarioL
    {
        private CInsertarHorarioD datosHorario;

        public clInsertarHorarioL()
        {
            datosHorario = new CInsertarHorarioD();
        }

        public string RegistrarHorario(clHorarioI horario)
        {
           
            if (horario == null)
                return "El horario no puede ser nulo.";

            if (horario.IdInstructor <= 0)
                return "El ID del instructor no es válido.";

            if (horario.IdFicha <= 0)
                return "El ID de la ficha no es válido.";

            if (horario.IdAmbiente <= 0)
                return "El ID del ambiente no es válido.";

            if (horario.fechaInicio >= horario.fechaFinal)
                return "La fecha de inicio debe ser anterior a la fecha final.";

            if (horario.horaInicio >= horario.horaFinal)
                return "La hora de inicio debe ser anterior a la hora final.";

            if (!horario.lunes && !horario.martes && !horario.miercoles &&
                !horario.jueves && !horario.viernes && !horario.sabado)
                return "Debe seleccionar al menos un día para el horario.";

            return datosHorario.InsertarHorario(horario);
        }

       
        public Dictionary<string, List<object>> ObtenerDisponibilidad()
        {
            return datosHorario.ObtenerDisponibilidad();
        }
    }
}
