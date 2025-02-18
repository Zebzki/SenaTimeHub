using System;
using System.Collections.Generic;

namespace Sena_TimeHub.entidades
{
    public class clHorario : clDia
    {
        public int idHorario { get; set; }
        public int IdInstructor { get; set; }
        public int IdFicha { get; set; }
        public int IdAmbiente { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFinal { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFinal { get; set; }
        public string ambiente { get; set; }
        public string ficha { get; set; }
        public bool esCancelada { get; set; }
        public string nombreMateria { get; set; }
        public string tipoMateria { get; set; }
        public string instructor { get; set; }
        public List<string> dias { get; set; }
        public clHorario()
        {
            dias = new List<string>();
        }
    }
}
