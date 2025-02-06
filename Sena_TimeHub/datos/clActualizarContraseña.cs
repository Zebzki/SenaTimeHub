using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clActualizarContraseña
    {
        public bool mtdActualizarC(string contraseña,int idU)
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            bool exito = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("spActualizarContraseña", cone))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pass", contraseña);
                    cmd.Parameters.AddWithValue("@IdUsuario", idU);
                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0)
                    {
                        exito = true;
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.mtdCerrarConexion();
            }
            return exito;
        }
    }

}