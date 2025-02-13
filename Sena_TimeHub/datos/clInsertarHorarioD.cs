using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class CInsertarHorarioD
    {
      
        public string InsertarHorario(clHorarioI horario)
        {
            string mensaje = string.Empty;
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            bool exito = false;

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_registrarHorario", cone))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idAmbiente", horario.IdAmbiente);
                    cmd.Parameters.AddWithValue("@idInstructor", horario.IdInstructor);
                    cmd.Parameters.AddWithValue("@idFicha", horario.IdFicha);
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
            return mensaje;
        }

       
        public Dictionary<string, List<object>> ObtenerDisponibilidad()
        {
            Dictionary<string, List<object>> disponibilidad = new Dictionary<string, List<object>>
            {
                { "Instructores", new List<object>() },
                { "Ambientes", new List<object>() },
                { "Fichas", new List<object>() }
            };

            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion(); 

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_obtenerDisponibilidad", cone))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            disponibilidad["Instructores"].Add(new
                            {
                                IdInstructor = reader["idInstructor"],
                                NombreInstructor = reader["nombreInstructor"],
                                Area = reader["Area"],
                                Tipo = reader["Tipo"]

                            });
                        }

                        reader.NextResult(); 
                        while (reader.Read())
                        {
                            disponibilidad["Ambientes"].Add(new
                            {
                                IdAmbiente = reader["idAmbiente"],
                                NombreAmbiente = reader["nombreAmbiente"]
                            });
                        }

                        reader.NextResult(); 
                        while (reader.Read())
                        {
                            disponibilidad["Fichas"].Add(new
                            {
                                IdFicha = reader["idFicha"],
                                NumeroFicha = reader["numeroFicha"],
                                NombrePrograma = reader["Programa"]
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener disponibilidad: " + ex.Message);
            }
            finally
            {
                con.mtdCerrarConexion(); 
            }
            return disponibilidad;
        }
    }
}
