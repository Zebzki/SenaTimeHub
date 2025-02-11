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

        public List<clAprendizE> MtdObtenerAprendicesPorFicha(int idFicha)
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            List<clAprendizE> aprendices = new List<clAprendizE>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerAprendicesPorFicha", cone))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idFicha", idFicha);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clAprendizE user = new clAprendizE()
                            {
                                idAprendiz = reader.GetInt32(reader.GetOrdinal("idAprendiz")),
                                nombreAprendiz = reader.GetString(reader.GetOrdinal("nombreAprendiz")),
                                apellidoAprendiz = reader.GetString(reader.GetOrdinal("apellidoAprendiz")),
                                emailAprendiz = reader.GetString(reader.GetOrdinal("emailAprendiz"))
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
