using Sena_TimeHub.entidades;
using Sena_TimeHub.logica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clEditarAprendiz
    {
        public void EditarAprendiz(clAprendizE aprendiz)
        {
            clConexion con = new clConexion();
            SqlConnection cone  = con.mtdAbrirConexion();
            try
            {
                using (SqlCommand cmd = new SqlCommand("spActualizarAprendiz", cone))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idAprendiz", aprendiz.idAprendiz);
                    cmd.Parameters.AddWithValue("@nombre", aprendiz.nombreAprendiz);
                    cmd.Parameters.AddWithValue("@apellido", aprendiz.apellidoAprendiz);
                    cmd.Parameters.AddWithValue("@tipoDocumento", aprendiz.tipoDocumentoAprendiz);
                    cmd.Parameters.AddWithValue("@documento", aprendiz.documentoAprendiz);
                    cmd.Parameters.AddWithValue("@email", aprendiz.emailAprendiz);
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