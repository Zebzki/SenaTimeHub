using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Sena_TimeHub.entidades;

namespace Sena_TimeHub.datos
{
    public class clListarAprendicesD
    {
        public List<clFichaE> ObtenerFichas()
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            List<clFichaE> fichas = new List<clFichaE>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerFichasActiva", cone))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clFichaE ficha = new clFichaE
                            {
                                idFicha = Convert.ToInt32(reader["idFicha"]),
                                numeroFicha = reader["numeroFicha"].ToString()
                            };
                            fichas.Add(ficha);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener fichas: " + ex.Message);
            }
            finally
            {
                con.mtdCerrarConexion();
            }
            return fichas;
        }

        public List<clUsuarioE> MtdObtenerAprendicesPorFicha(int idFicha)
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            List<clUsuarioE> aprendices = new List<clUsuarioE>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerAprendicesPorFicha", cone))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FichaId", idFicha);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clUsuarioE user = new clUsuarioE()
                            {
                                idUsuario = reader.GetInt32(reader.GetOrdinal("AprendizId")),
                                nombre = reader.GetString(reader.GetOrdinal("NombreAprendiz")),
                                apellido = reader.GetString(reader.GetOrdinal("ApellidoAprendiz")),
                                email = reader.GetString(reader.GetOrdinal("Email"))
                            };
                            aprendices.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener aprendices: " + ex.Message);
            }
            finally
            {
                con.mtdCerrarConexion();
            }
            return aprendices;
        }
    }
}
