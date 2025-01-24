using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clAprendizL
    {
        public clAprendizE mtdIngresoAprendiz(clAprendizE oData)
        {
            clAprendizD oAprendiz = new clAprendizD();
            return oAprendiz.mtdIngresoAprendiz(oData);
        }
    }
}