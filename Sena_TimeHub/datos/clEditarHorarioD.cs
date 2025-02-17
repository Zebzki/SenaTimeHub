using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Sena_TimeHub.entidades;

namespace Sena_TimeHub.datos
{
    public class clEditarHorarioD
    {

        public Boolean EditarHorario(clHorario horario)
        {
            string mensaje = string.Empty;
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            bool exito = false;

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_editarHorario", cone))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idHorario", horario.idHorario);
                    cmd.Parameters.AddWithValue("@idAmbiente", horario.idAmbiente);
                    cmd.Parameters.AddWithValue("@idInstructor", horario.idUsuario);
                    cmd.Parameters.AddWithValue("@idFicha", horario.idFicha);
                    cmd.Parameters.AddWithValue("@fechaInicio", horario.fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaFinal", horario.fechaFinal);
                    cmd.Parameters.AddWithValue("@horaInicio", horario.horaInicio);
                    cmd.Parameters.AddWithValue("@horaFinal", horario.horaFinal);

                    cmd.Parameters.AddWithValue("@lunes", horario.lunes);
                    cmd.Parameters.AddWithValue("@martes", horario.martes);
                    cmd.Parameters.AddWithValue("@miercoles", horario.miercoles);
                    cmd.Parameters.AddWithValue("@jueves", horario.jueves);
                    cmd.Parameters.AddWithValue("@viernes", horario.viernes);
                    cmd.Parameters.AddWithValue("@sabado", horario.sabado);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            mensaje = reader["mensaje"].ToString();
                            exito = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error: " + ex.Message;
            }
            finally
            {
                con.mtdCerrarConexion();
            }
            return exito;
        }

        public Dictionary<string, object> ObtenerHorarioPorId(int idHorario)
        {
            Dictionary<string, object> horario = new Dictionary<string, object>();
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();

            try
            {
                using (SqlCommand cmd = new SqlCommand("spObtenerHorarioPorId", cone))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idHorario", idHorario);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            horario["idHorario"] = reader["idHorario"];
                            horario["idInstructor"] = reader["idUsuario"];
                            horario["idFicha"] = reader["idFicha"];
                            horario["idAmbiente"] = reader["idAmbiente"];
                            horario["fechaInicio"] = reader["fechaInicio"];
                            horario["fechaFinal"] = reader["fechaFinal"];
                            horario["horaInicio"] = reader["horaInicio"];
                            horario["horaFinal"] = reader["horaFinal"];
                        }

                        reader.NextResult();
                        if (reader.Read())
                        {
                            horario["lunes"] = Convert.ToBoolean(reader["lunes"]);
                            horario["martes"] = Convert.ToBoolean(reader["martes"]);
                            horario["miercoles"] = Convert.ToBoolean(reader["miercoles"]);
                            horario["jueves"] = Convert.ToBoolean(reader["jueves"]);
                            horario["viernes"] = Convert.ToBoolean(reader["viernes"]);
                            horario["sabado"] = Convert.ToBoolean(reader["sabado"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el horario: " + ex.Message);
            }
            finally
            {
                con.mtdCerrarConexion();
            }
            return horario;
        }


        public clHorario ObtenerHorario(int idHorario)
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            clHorario horario = null;
            
            {
                SqlCommand cmd = new SqlCommand("spObtenerHorarioPorId", cone);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idHorario", idHorario);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    horario = new clHorario
                    {
                        idHorario = Convert.ToInt32(reader["IdHorario"]),
                        IdInstructor = Convert.ToInt32(reader["IdInstructor"]),
                        IdFicha = Convert.ToInt32(reader["IdFicha"]),
                        IdAmbiente = Convert.ToInt32(reader["IdAmbiente"]),
                        fechaInicio = Convert.ToDateTime(reader["fechaInicio"]),
                        fechaFinal = Convert.ToDateTime(reader["fechaFinal"]),
                        horaInicio = TimeSpan.Parse(reader["horaInicio"].ToString()),
                        horaFinal = TimeSpan.Parse(reader["horaFinal"].ToString()),
                        lunes = Convert.ToBoolean(reader["lunes"]),
                        martes = Convert.ToBoolean(reader["martes"]),
                        miercoles = Convert.ToBoolean(reader["miercoles"]),
                        jueves = Convert.ToBoolean(reader["jueves"]),
                        viernes = Convert.ToBoolean(reader["viernes"]),
                        sabado = Convert.ToBoolean(reader["sabado"])
                    };
                }
            }
            con.mtdCerrarConexion();
            return horario;
        }


    }
}