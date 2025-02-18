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
            con = new SqlConnection("Data Source=.;Initial Catalog=dbSenaTimeHub;Integrated Security=True;");
           
            //con = new SqlConnection("Data Source=.;Initial Catalog=dbSenaTimeHub;User ID=zebzki;Password=12345;");

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