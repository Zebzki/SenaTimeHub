using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clRegistrarAmbienteL
    {
        private readonly clRegistrarAmbienteD ambiente = new clRegistrarAmbienteD();

        public string RegistrarAmbiente(string nombreAmbiente, string nombreSede, string imagenAmbiente)
        {
            clAmbienteE nuevoAmbiente = new clAmbienteE
            {
                nombreAmbiente = nombreAmbiente,
                imagenAmbiente = imagenAmbiente
            };

            ambiente.RegistrarAmbiente(nuevoAmbiente, nombreSede);
            return "Ambiente registrado correctamente!!!";
        }

    }
}