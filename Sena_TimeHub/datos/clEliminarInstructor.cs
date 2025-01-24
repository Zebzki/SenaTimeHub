using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clEliminarInstructor
    {
        public bool mtdEliminarI(int id)
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            bool exito = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("spEliminarI", cone))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idU", id);
                    cmd.ExecuteNonQuery();
                    
                        exito = true;
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"error en clEliminarD {e.Message}");
            }
            finally
            {
                con.mtdCerrarConexion();

            }
            return exito;
        }
    }
}