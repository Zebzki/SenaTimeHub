﻿using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clActualizarSedeL
    {
        public bool mtdEditarSede (clSedeE oS)
        {
            clActualizarSedeD oEditarSede = new clActualizarSedeD();
            return oEditarSede.MtdEditarSede (oS);    
        }
    }
}