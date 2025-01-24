using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clListarInstructorD
    {
        public List<clUsuarioE> mtdListarInstructor(int id)
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            List<clUsuarioE> lista = new List<clUsuarioE>();

            try
            {
                using (SqlCommand cmd = new SqlCommand("spListarApoyoC", cone))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idrol", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clUsuarioE oU = new clUsuarioE()
                            {
                                idUsuario = reader.GetInt32(reader.GetOrdinal("idUsuario")),
                                nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                apellido = reader.GetString(reader.GetOrdinal("apellido")),
                                tipoDocumento = reader.GetString(reader.GetOrdinal("tipoDocumento")),
                                documento = reader.GetString(reader.GetOrdinal("documento")),
                                email = reader.GetString(reader.GetOrdinal("email"))
                            };
                            lista.Add(oU);
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