using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clListarProgramaD
    {
        public List<clProgramaE> mtdListarPrograma()
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            List<clProgramaE> lista = new List<clProgramaE>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("spListarPrograma", cone))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clProgramaE user = new clProgramaE()
                            {
                                idPrograma = reader.GetInt32(reader.GetOrdinal("idPrograma")),
                                nombrePrograma = reader.GetString(reader.GetOrdinal("nombrePrograma")),
                                version = reader.GetString(reader.GetOrdinal("version")),
                                codigo = reader.GetString(reader.GetOrdinal("codigo")),
                                tipo = reader.GetString(reader.GetOrdinal("tipoPrograma"))
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