using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.entidades
{
    public class clUsuarioE : clRol
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string tipoDocumento { get; set; }
        public string documento { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }
        public string tipo { get; set; }
        public bool validar { get; set; }



    }
}