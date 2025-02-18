using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clListarHorarioL
    {


        public List<clHorario> ObtenerHorarios(int idFicha)
        {
            clListarHorarioD horarioDatos = new clListarHorarioD();
            return horarioDatos.ObtenerHorariosPorFicha(idFicha);
        }

    }
}