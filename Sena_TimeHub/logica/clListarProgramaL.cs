using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clListarProgramaL
    {
        public List<clProgramaE> mtdListarPrograma()
        {
            clListarProgramaD oLista = new clListarProgramaD();
            return oLista.mtdListarPrograma();
        }
    }
}