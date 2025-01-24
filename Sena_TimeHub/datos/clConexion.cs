using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Sena_TimeHub.datos
{
    
    public class clConexion
    {
        SqlConnection con;

        public clConexion()
        {

            con = new SqlConnection("Data Source=.;Initial Catalog=dbProyecto2;Integrated Security=True;");

        }
        public SqlConnection mtdAbrirConexion()
        {
            con.Open();
            return con;
        }
        public SqlConnection mtdCerrarConexion()
        {
            con.Close();
            return con;
        }
    }
}