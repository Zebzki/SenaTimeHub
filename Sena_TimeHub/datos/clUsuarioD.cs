using Sena_TimeHub.entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Sena_TimeHub.datos
{
    public class clUsuarioD
    {
        clConexion con = new clConexion();

        public clUsuarioE mtdIngreso(clUsuarioE oData)
        {
            clUsuarioE oDatos = null;
            SqlConnection conect = con.mtdAbrirConexion();
            try
            {
                using (SqlCommand cmd = new SqlCommand("spLoginUsuario", conect))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", oData.email);
                    cmd.Parameters.AddWithValue("@clave", oData.contraseña);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            oDatos = new clUsuarioE
                            {
                                idUsuario = reader.GetInt32(reader.GetOrdinal("idUsuario")),
                                nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                apellido = reader.GetString(reader.GetOrdinal("apellido")),
                                rol = reader.GetString(reader.GetOrdinal("rol"))
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en mtdIngreso: {ex.Message}");
            }
            finally
            {
                con.mtdCerrarConexion();
            }
            return oDatos;
        }

        public clUsuarioE mtdRecuperarContrasena(string idUsuario = null, string correo = null, string contrasena = null)
        {
            SqlConnection conect = con.mtdAbrirConexion();
            clUsuarioE objUsuarioE = new clUsuarioE();

            try
            {
                using (SqlCommand cmd = new SqlCommand("spRecuperarContrasena", conect))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (correo == null)
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", int.Parse(idUsuario));
                        cmd.Parameters.AddWithValue("@contrasena", contrasena);
                        cmd.ExecuteNonQuery();
                        objUsuarioE.validar = true;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@correo", correo);
                        using (SqlDataReader fila = cmd.ExecuteReader())
                        {
                            if (fila.Read())
                            {
                                objUsuarioE.idUsuario = int.Parse(fila["idUsuario"].ToString());
                                objUsuarioE.nombre = fila["nombre"].ToString();
                                objUsuarioE.apellido = fila["apellido"].ToString();
                                objUsuarioE.email = fila["email"].ToString();
                                objUsuarioE.validar = true;
                            }
                            else
                            {
                                objUsuarioE.validar = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objUsuarioE.validar = false;
                Console.WriteLine($"Error en mtdRecuperarContrasena: {ex.Message}");
            }
            finally
            {
                con.mtdCerrarConexion();
            }

            return objUsuarioE;
        }
    }
}
