using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.entidades
{
    public class clDia
    {
        public int idDia { get; set; }
        public bool lunes { get; set; }
        public bool martes { get; set; }
        public bool miercoles { get; set; }
        public bool jueves { get; set; }
        public bool viernes { get; set; }
        public bool sabado { get; set; }
        public clDia()
        {

            lunes = false;
            martes = false;
            miercoles = false;
            jueves = false;
            viernes = false;
            sabado = false;
        }
    }
}