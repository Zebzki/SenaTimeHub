using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sena_TimeHub.logica
{
    public class clFichaL
    {

        
        public bool RegistrarFichaYUsuarios(string numeroFicha, DateTime fechaInicio, DateTime fechaFinal, string jornada, int idPrograma,int idSede, DataTable aprendices)
        {
           clFichaD oFicha = new clFichaD();    
            return oFicha.RegistrarFicha(numeroFicha, fechaInicio, fechaFinal, jornada, idPrograma, idSede,  aprendices);

        }
     
        public DataTable CrearTablaUsuarios()
        {
            DataTable table = new DataTable();
            table.Columns.Add("nombre", typeof(string));
            table.Columns.Add("apellido", typeof(string));
            table.Columns.Add("tipoDocumento", typeof(string));
            table.Columns.Add("documento", typeof(string));
            table.Columns.Add("email", typeof(string));


            return table;
        }
        public List<clProgramaE> ObtenerProgramas()
        {
            clFichaD oFicha = new clFichaD();
            return oFicha.ObtenerProgramas();
        }
        public List<clSedeE> obtenerSedes()
        {
            clFichaD oFicha = new clFichaD();
            return oFicha.obtenerSede();
        }

    }
   
}

