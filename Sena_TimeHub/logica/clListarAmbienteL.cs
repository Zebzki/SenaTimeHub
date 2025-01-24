using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clListarAmbienteL
    {
        public List<clAmbienteE> mtdListarAmbiente()
        {
            clListarAmbienteD oLista = new clListarAmbienteD();
            return oLista.MtdListarAmbiente();
        }

    }
}