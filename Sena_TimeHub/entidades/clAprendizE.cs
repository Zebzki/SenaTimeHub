using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.entidades
{
    public class clAprendizE
    {
        public int idAprendiz { get; set; }
        public string nombreAprendiz { get; set; }
        public string apellidoAprendiz { get; set; }
        public string tipoDocumentoAprendiz { get; set; }
        public string documentoAprendiz { get; set; }
        public string emailAprendiz { get; set; }
        public string contrasenaAprendiz { get; set; }
        public bool  validarAprendiz { get; set; }

    }
}