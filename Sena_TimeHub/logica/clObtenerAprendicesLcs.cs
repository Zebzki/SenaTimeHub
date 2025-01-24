using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clObtenerAprendicesLcs
    {
        public clUsuarioE ObtenerAprendizPorId(int idUsuario)
        {
            clObtenerAprendices datos = new clObtenerAprendices();
            return datos.ObtenerAprendizPorId(idUsuario); 
        }
    }
}