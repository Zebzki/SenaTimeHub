using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clListarCoordinacionD
    {
        public List<clUsuarioE> mtdListarCoordinacion(int idRol)
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            List<clUsuarioE> lista = new List<clUsuarioE>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("spListarApoyoC", cone))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idrol", idRol);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clUsuarioE user = new clUsuarioE()
                            {
                                idUsuario = reader.GetInt32(reader.GetOrdinal("idUsuario")),
                                nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                apellido = reader.GetString(reader.GetOrdinal("apellido")),
                                tipoDocumento = reader.GetString(reader.GetOrdinal("tipoDocumento")),
                                documento = reader.GetString(reader.GetOrdinal("documento")),
                                email = reader.GetString(reader.GetOrdinal("email"))
                            };
                            lista.Add(user);
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
            return lista;
        }
    }
}