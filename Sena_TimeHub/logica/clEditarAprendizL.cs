using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clEditarAprendizL
    {
        private clEditarAprendiz datos = new clEditarAprendiz();
        public bool EditarAprendiz(clUsuarioE aprendiz)
        {
            datos.EditarAprendiz(aprendiz);
            return true;
        }
       
    }
}