using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clRegistroCoordinacionD
    {
        public bool mtdRegistro(clUsuarioE oData)
        {
            clConexion con = new clConexion();
            SqlConnection conexion = con.mtdAbrirConexion();
            bool exito = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("spRegistrarApoyoC", conexion))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", oData.nombre);
                    cmd.Parameters.AddWithValue("@apellido", oData.apellido);
                    cmd.Parameters.AddWithValue("@tipoDocumento", oData.tipoDocumento);
                    cmd.Parameters.AddWithValue("@documento", oData.documento);
                    cmd.Parameters.AddWithValue("@email", oData.email);
                    cmd.Parameters.AddWithValue("@idRol", oData.idRol);
                    cmd.ExecuteNonQuery();
                    exito = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.mtdCerrarConexion();

            }
            return exito;
        }
    }
}