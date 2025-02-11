using System.Collections.Generic;
using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;

namespace Sena_TimeHub.logica
{
    public class clListarAprendicesL
    {
        private clListarAprendicesD datos = new clListarAprendicesD();

        public List<clFichaE> ObtenerFichas()
        {
            return datos.ObtenerFichas();
        }

        public List<clAprendizE> ObtenerAprendicesPorFicha(int idFicha)
        {
            return datos.MtdObtenerAprendicesPorFicha(idFicha);
        }
    }
}
