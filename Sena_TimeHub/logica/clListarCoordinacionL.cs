using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clListarCoordinacionL
    {
        public List<clUsuarioE> mtdListarC(int idRol)
        {
            clListarCoordinacionD oLista = new clListarCoordinacionD();
            return oLista.mtdListarCoordinacion(idRol);
        }
    }
}