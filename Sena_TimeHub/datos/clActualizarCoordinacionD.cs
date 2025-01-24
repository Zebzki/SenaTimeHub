using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clActualizarCoordinacionD
    {
        public bool mtdActualizarC(clUsuarioE oUsuario)
        {
            clConexion con = new clConexion();
            SqlConnection conexion = con.mtdAbrirConexion();
            bool exito = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("spActualizarApoyoC", conexion))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario", oUsuario.idUsuario);
                    cmd.Parameters.AddWithValue("@nombre", oUsuario.nombre);
                    cmd.Parameters.AddWithValue("@apellido", oUsuario.apellido);
                    cmd.Parameters.AddWithValue("@tipoDocumento", oUsuario.tipoDocumento);
                    cmd.Parameters.AddWithValue("@documento", oUsuario.documento);
                    cmd.Parameters.AddWithValue("@email", oUsuario.email);
                    cmd.ExecuteNonQuery();
                    exito = true;

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