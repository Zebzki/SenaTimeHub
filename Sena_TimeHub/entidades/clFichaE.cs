using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.entidades
{
    public class clFichaE:clProgramaE
    {

        public int idFicha { get; set; }
        public string numeroFicha { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFinal { get; set; }
        public string estado { get; set; }
        public string jornada { get; set; }



    }
}