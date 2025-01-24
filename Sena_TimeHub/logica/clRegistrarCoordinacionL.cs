using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.logica
{
    public class clRegistrarCoordinacionL
    {
        public bool mtdRegistrar(clUsuarioE data)
        {
            clRegistroCoordinacionD oR = new clRegistroCoordinacionD();
            return oR.mtdRegistro(data);
        }
    }
}