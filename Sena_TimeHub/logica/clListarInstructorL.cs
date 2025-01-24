using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clListarInstructorL
    {
        public List<clUsuarioE> mtdListarI (int id)
        {
            clListarInstructorD oL = new clListarInstructorD();
            return oL.mtdListarInstructor(id);
        }
    }
}