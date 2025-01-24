using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clObtenerCoordinacionL
    {
        public clUsuarioE mtdObtenerC (int id)
        {
            clObtenerCoordinacionD oC = new clObtenerCoordinacionD ();
            return oC.mtdObtenerCoordinacion(id);
        }
    }
}