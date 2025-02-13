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
                    cmd.Parameters.AddWithValue("@nombreAprendiz", aprendiz.nombreAprendiz);
                    cmd.Parameters.AddWithValue("@apellidoAprendiz", aprendiz.apellidoAprendiz);
                    cmd.Parameters.AddWithValue("@tipoDocumentoAprendiz", aprendiz.tipoDocumentoAprendiz);
                    cmd.Parameters.AddWithValue("@documentoAprendiz", aprendiz.documentoAprendiz );
                    cmd.Parameters.AddWithValue("@emailAprendiz", aprendiz.emailAprendiz);
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