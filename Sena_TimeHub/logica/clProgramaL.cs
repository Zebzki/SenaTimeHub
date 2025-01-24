using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clProgramaL
    {
        public void MtdRegistrarPrograma(clProgramaE objPrograma)
        {
            clProgramaD oDatos = new clProgramaD();
            oDatos.MtdRegistrarPrograma(objPrograma);
        }
    }
}