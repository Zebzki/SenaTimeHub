using System;
using Sena_TimeHub.entidades;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace Sena_TimeHub.datos
{
    public class clListarHorarioD
    {
        public List<clHorario> ObtenerHorariosPorFicha(int idFicha)
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();

            List<clHorario> listaHorarios = new List<clHorario>();
            try
            {
                using (SqlCommand comando = new SqlCommand("spObtenerHorarioPorFicha", cone))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idFicha", idFicha);


                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        listaHorarios.Add(new clHorario
                        {
                            idHorario = reader.GetInt32(reader.GetOrdinal("idHorario")),
                            nombre = reader["nombre"].ToString(),
                            apellido = reader["apellido"].ToString(),
                            nombrePrograma = reader["nombrePrograma"].ToString(),
                            numeroFicha = reader["numeroFicha"].ToString(),
                            nombreAmbiente = reader["nombreAmbiente"].ToString(),
                            fechaInicio = reader.GetDateTime(reader.GetOrdinal("fechaInicio")).Date,
                            fechaFinal = reader.GetDateTime(reader.GetOrdinal("fechaFinal")).Date,
                            horaInicio = reader.GetTimeSpan(reader.GetOrdinal("horaInicio")),
                            horaFinal = reader.GetTimeSpan(reader.GetOrdinal("horaFinal")),
                            lunes = reader.GetBoolean(reader.GetOrdinal("lunes")),
                            martes = reader.GetBoolean(reader.GetOrdinal("martes")),
                            miercoles = reader.GetBoolean(reader.GetOrdinal("miercoles")),
                            jueves = reader.GetBoolean(reader.GetOrdinal("jueves")),
                            viernes = reader.GetBoolean(reader.GetOrdinal("viernes")),
                            sabado = reader.GetBoolean(reader.GetOrdinal("sabado"))
                        });
                    }
                }

                return listaHorarios;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return listaHorarios;
            }
            finally
            {
                con.mtdCerrarConexion();
            }
        }
    }
}

    