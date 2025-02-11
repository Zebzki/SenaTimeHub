using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clObtenerAprendicesYUsuarios
    {
        public clUsuarioE ObtenerUsuarioPorId(int idUsuario)
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            clUsuarioE usuario = null;

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
                            usuario = new clUsuarioE
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
            return usuario;
        }


        public clAprendizE ObtenerAprendizPorId(int idAprendiz)
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            clAprendizE aprendiz = null;

            try
            {
                using (SqlCommand cmd = new SqlCommand("spObtenerAP", cone))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idAprendiz", idAprendiz);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            aprendiz = new clAprendizE
                            {
                                idAprendiz = Convert.ToInt32(reader["idAprendiz"]),
                                nombreAprendiz = reader["nombreAprendiz"].ToString(),
                                apellidoAprendiz = reader["apellidoAprendiz"].ToString(),
                                tipoDocumentoAprendiz = reader["tipoDocumentoAprendiz"].ToString(),
                                documentoAprendiz = reader["documentoAprendiz"].ToString(),
                                emailAprendiz = reader["emailAprendiz"].ToString()
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