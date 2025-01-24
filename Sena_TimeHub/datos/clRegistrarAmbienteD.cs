using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clRegistrarAmbienteD
    {

        private clConexion conexion = new clConexion();

        public void RegistrarAmbiente(clAmbienteE ambiente, string nombreSede)
        {
            using (SqlConnection con = conexion.mtdAbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spRegistrarAmbiente", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@nombreAmbiente", ambiente.nombreAmbiente);
                    cmd.Parameters.AddWithValue("@imagenAmbiente", ambiente.imagenAmbiente);
                    cmd.Parameters.AddWithValue("@nombreSede", nombreSede);


                    cmd.ExecuteNonQuery();
                }
            }
            conexion.mtdCerrarConexion();
        }

    }
}