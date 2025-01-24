using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clListarFichaL
    {
        public List<clFichaE> mtdListarF(int idFicha)
        {
            clListarFichaD oListaFicha = new clListarFichaD();
            return oListaFicha.MtdListarFichas(idFicha);
        }
    }

}