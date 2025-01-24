using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clEliminarSedeD
    {

        public bool mtdEliminarSede(int idSede)
        {
            clConexion con = new clConexion();
            SqlConnection conexion = con.mtdAbrirConexion();
            bool exito = true;
            try
            {
                using (SqlCommand cmd = new SqlCommand("spEliminarSede", conexion))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idSede", idSede);
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        exito = true;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.mtdCerrarConexion();
            }
            return exito;
        }

    }
}