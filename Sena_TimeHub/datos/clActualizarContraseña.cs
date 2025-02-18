using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clActualizarContraseña
    {
        public bool mtdActualizarCU(string contraseña,int idU)
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            bool exito = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("spActualizarContraseñaU", cone))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pass", contraseña);
                    cmd.Parameters.AddWithValue("@IdUsuario", idU);
                     cmd.ExecuteNonQuery();
                    
                        exito = true;
                    

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error en capa datos Usuario" + ex.ToString());
            }
            finally
            {
                con.mtdCerrarConexion();
            }
            return exito;
        }
        public bool mtdActualizarCA(string contraseña, int idA)
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            bool exito = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("spActualizarContraseñaA", cone))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pass", contraseña);
                    cmd.Parameters.AddWithValue("@IdAprendiz", idA);
                     cmd.ExecuteNonQuery();
                   
                        exito = true;
                    

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error en capa datos"+ex.ToString());
            }
            finally
            {
                con.mtdCerrarConexion();
            }
            return exito;
        }
    }

}