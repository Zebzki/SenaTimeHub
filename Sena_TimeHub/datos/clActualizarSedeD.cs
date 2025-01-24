using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clActualizarSedeD
    {
        public bool MtdEditarSede(clSedeE oSede)
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            bool exito = true;
            try
            {
                using (SqlCommand cmd = new SqlCommand("spEditarSede", cone))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idSede", oSede.idSede);
                    cmd.Parameters.AddWithValue("@nombreSede", oSede.nombreSede ?? (object)DBNull.Value);
                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0)
                    {
                        return exito = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return exito = false;
            }
            finally
            {
                con.mtdCerrarConexion();
            }
            return exito;
        }
    }
}