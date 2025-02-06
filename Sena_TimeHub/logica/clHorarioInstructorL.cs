using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clHorarioInstructorL
    {
        private clHorarioInstructorD horarioI = new clHorarioInstructorD();
        public List<clHorario> mtdHorarioInstructor (int idInstructor)
        {
            return horarioI.mtdHorarioInstructor(idInstructor);
        }
        public bool mtdCancelarClasesPorFecha(int idHorario, DateTime fecha, string motivo)
        {
            return horarioI.mtdCancelarClasesPorFecha(idHorario, fecha,motivo);
        }
        public List<DateTime> mtdObtenerFechasCanceladas(int idInstructor)
        {
            return horarioI.mtdObtenerFechasCanceladas(idInstructor);
        }
        public List<string> mtdObtenerCorreos (int idFicha)
        {
            return horarioI.mtdObtenerCorreos(idFicha); 
        }
        public int mtdObtenerFichaPorHorario(int idHorario)
        {
            return horarioI.mtdObtenerFichaPorHorario(idHorario);
        }
        //public bool mtdCancelarClase(clHorario oData)
        //{
        //    return horarioI.mtdCancelarHorario(oData);
        //}


    }
}