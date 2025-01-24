using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clRegistrarAreaD
    {
        private clConexion conexion = new clConexion();

        public void RegistrarArea(clArea area, string nombreArea)
        {
            using (SqlConnection con = conexion.mtdAbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spRegistrarArea", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@nombreArea", area.nombreArea);


                    cmd.ExecuteNonQuery();
                }
            }
            conexion.mtdCerrarConexion();
        }
    }
}