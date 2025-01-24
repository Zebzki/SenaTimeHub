using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clObtenerAprendices
    {
        public clUsuarioE ObtenerAprendizPorId(int idUsuario)
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            clUsuarioE aprendiz = null;

            try
            {
                using (SqlCommand cmd = new SqlCommand("spObtenerAC", cone))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            aprendiz = new clUsuarioE
                            {
                                idUsuario = Convert.ToInt32(reader["idUsuario"]),
                                nombre = reader["nombre"].ToString(),
                                apellido = reader["apellido"].ToString(),
                                tipoDocumento = reader["tipoDocumento"].ToString(),
                                documento = reader["documento"].ToString(),
                                email = reader["email"].ToString()
                            };
                        }
                    }
                }
            }
            finally
            {
                con.mtdCerrarConexion();
            }
            return aprendiz;
        }

    }
}