using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clObtenerSedeL
    {
        private readonly clObtenerSedeD sede = new clObtenerSedeD();

        public List<clSedeE> obtenerSede()
        {
            return sede.ObtenerSede();
        }

        public clSedeE mtdObtenerSede(int id)
            {
                clObtenerSedeD oSede = new clObtenerSedeD();
                return oSede.mtdObtenerSede(id);
            }
        }

    }
