using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clEliminarCoordinacionD
    {
        public bool mtdEliminacionC(int id)
        {
            clConexion con = new clConexion();
            SqlConnection conexion = con.mtdAbrirConexion();
            bool exito = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("spEliminarApoyoC",conexion))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
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