using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clRegistrarAreaL
    {
        private readonly clRegistrarAreaD area = new clRegistrarAreaD();

        public string RegistrarArea(string nombreArea, string tipo)
        {
            clArea nuevaArea = new clArea
            {
                nombreArea = nombreArea,
                tipo = tipo
            };

            area.RegistrarArea(nuevaArea, nombreArea, tipo);
            return "Area registrado correctamente!!!";
        }
    }
}