using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clRegistrarSedeD
    {

        private clConexion conexion = new clConexion();

        public void RegistrarSede(clSedeE sede)
        {
            using (SqlConnection con = conexion.mtdAbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spRegistrarSede", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@nombreSede", sede.nombreSede);


                    cmd.ExecuteNonQuery();
                }
            }
            conexion.mtdCerrarConexion();
        }

    }
}