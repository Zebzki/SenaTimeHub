using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clEditarAprendiz
    {
        public void EditarAprendiz(clUsuarioE aprendiz)
        {
            clConexion con = new clConexion();
            SqlConnection cone  = con.mtdAbrirConexion();
            try
            {
                using (SqlCommand cmd = new SqlCommand("spActualizarAprendiz", cone))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario", aprendiz.idUsuario);
                    cmd.Parameters.AddWithValue("@nombre", aprendiz.nombre);
                    cmd.Parameters.AddWithValue("@apellido", aprendiz.apellido);
                    cmd.Parameters.AddWithValue("@tipoDocumento", aprendiz.tipoDocumento);
                    cmd.Parameters.AddWithValue("@documento", aprendiz.documento);
                    cmd.Parameters.AddWithValue("@email", aprendiz.email);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                con.mtdCerrarConexion();
            }
        }
    }
    
}