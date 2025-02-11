using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clObtenerCoordinacionD
    {
        public clUsuarioE mtdObtenerCoordinacion(int id)
        {
            clConexion con = new clConexion();
            SqlConnection conexion = con.mtdAbrirConexion();
            clUsuarioE oUsuario = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("spObtenerAC", conexion))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            oUsuario = new clUsuarioE()
                            {
                                idUsuario = reader.GetInt32(reader.GetOrdinal("idUsuario")),
                                nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                apellido = reader.GetString(reader.GetOrdinal("apellido")),
                                tipoDocumento = reader.GetString(reader.GetOrdinal("tipoDocumento")),
                                documento = reader.GetString(reader.GetOrdinal("documento")),
                                email = reader.GetString(reader.GetOrdinal("email"))
                            };

                        }

                    }
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
            return oUsuario;
        }
    }
}