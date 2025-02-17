using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clObtenerInstructorL
    {


        public List<clUsuarioE> ObtenerInstructor()
        {
        clObtenerInstructorD instructor = new clObtenerInstructorD();
            return instructor.ObtenerInstructor();
        }

    }
}