using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clRegistrarSedeL
    {
        private readonly clRegistrarSedeD sede = new clRegistrarSedeD();

        public string RegistrarSede(string nombreSede)
        {
            clSedeE nuevaSede = new clSedeE
            {
                nombreSede = nombreSede
            };

            sede.RegistrarSede(nuevaSede);
            return "Sede registrada correctamente!!!";
        }

    }
}