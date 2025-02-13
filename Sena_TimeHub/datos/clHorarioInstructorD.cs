using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clHorarioInstructorD
    {

        public List<clHorarioI> mtdHorarioInstructor(int idInstructor)
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            List<clHorarioI> horarios = new List<clHorarioI>();

            List<DateTime> fechasCanceladas = mtdObtenerFechasCanceladas(idInstructor);
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerFechasInstructor", cone))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idInstructor", idInstructor);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clHorarioI horario = new clHorarioI
                            {
                                idHorario = reader.GetInt32(reader.GetOrdinal("idHorario")),
                                fechaInicio = reader.GetDateTime(reader.GetOrdinal("fechaInicio")),
                                fechaFinal = reader.GetDateTime(reader.GetOrdinal("fechaFinal")),
                                horaInicio = reader.GetTimeSpan(reader.GetOrdinal("horaInicio")),
                                horaFinal = reader.GetTimeSpan(reader.GetOrdinal("horaFinal")),
                                ficha = reader.GetString(reader.GetOrdinal("ficha")),
                                ambiente = reader.GetString(reader.GetOrdinal("ambiente")),
                          
                                dias = new List<string>()
                            };

                            // Identificar qué días tiene clase
                            if (reader.GetBoolean(reader.GetOrdinal("lunes"))) horario.dias.Add("lunes");
                            if (reader.GetBoolean(reader.GetOrdinal("martes"))) horario.dias.Add("martes");
                            if (reader.GetBoolean(reader.GetOrdinal("miercoles"))) horario.dias.Add("miércoles");
                            if (reader.GetBoolean(reader.GetOrdinal("jueves"))) horario.dias.Add("jueves");
                            if (reader.GetBoolean(reader.GetOrdinal("viernes"))) horario.dias.Add("viernes");
                            if (reader.GetBoolean(reader.GetOrdinal("sabado"))) horario.dias.Add("sábado");
                            DateTime currentDate = horario.fechaInicio;
                            while (currentDate <= horario.fechaFinal)
                            {
                                string dayOfWeek = currentDate.ToString("dddd", new System.Globalization.CultureInfo("es-ES")).ToLower();
                                if (horario.dias.Contains(dayOfWeek))
                                {
                                    bool esCancelada = fechasCanceladas.Contains(currentDate);
                                    clHorarioI dayHorario = new clHorarioI
                                    {
                                        idHorario = horario.idHorario,
                                        fechaInicio = currentDate,
                                        fechaFinal = currentDate,
                                        horaInicio = horario.horaInicio,
                                        horaFinal = horario.horaFinal,
                                        ficha = horario.ficha,

                                        ambiente = horario.ambiente,
                                        esCancelada = esCancelada,
                                        dias = new List<string> { dayOfWeek }
                                    };
                                    horarios.Add(dayHorario);
                                }
                                currentDate = currentDate.AddDays(1);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error en el mtdHorarioInstructor" + ex.Message);
            }
            finally
            {
                con.mtdCerrarConexion();
            }
            return horarios;
        }
        public bool mtdCancelarClasesPorFecha(int idHorario, DateTime fechaCancelacion, string motivo)
        {
            clConexion con = new clConexion();
            bool exito = false;
            SqlConnection cone = con.mtdAbrirConexion();

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_CancelarClasesPorFecha", cone))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idHorario", idHorario);
                    cmd.Parameters.AddWithValue("@fechaCancelada", fechaCancelacion);
                    cmd.Parameters.AddWithValue("@motivo", motivo);

                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0)
                    {
                        exito = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error en mtdCancelarClases{ex.Message}");
            }
            finally
            {
                con.mtdCerrarConexion();
            }

            return exito;
        }
        public List<DateTime> mtdObtenerFechasCanceladas(int idInstructor)
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            List<DateTime> fechasCanceladas = new List<DateTime>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerFechasCanceladasInstructor", cone))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idInstructor", idInstructor);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fechasCanceladas.Add(reader.GetDateTime(reader.GetOrdinal("fechaCancelada")));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en mtdObtenerFechasCanceladas: " + ex.Message);
            }
            finally
            {
                con.mtdCerrarConexion();
            }
            return fechasCanceladas;
        }
        public List<string> mtdObtenerCorreos(int idFicha)
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            List<string> correos = new List<string>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerCorreosAprendices", cone))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idFicha", idFicha);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            correos.Add(reader.GetString(reader.GetOrdinal("emailAprendiz")));
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
            return correos;
        }
        public int mtdObtenerFichaPorHorario(int idHorario)
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            int idFicha = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerFichaPorHorario", cone))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idHorario", idHorario);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idFicha = reader.GetInt32(reader.GetOrdinal("idFicha"));
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
            return idFicha;
        }
        //public bool mtdCancelarHorario(clHorario oData)
        //{
        //    bool exito = false;
        //    SqlConnection cone = con.mtdAbrirConexion();
        //    try
        //    {
        //        using (SqlCommand cmd = new SqlCommand("spCancelarClase", cone))
        //        {
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@idHorario", oData.idHorario);
        //            cmd.Parameters.AddWithValue("@idDia", oData.idDia);
        //            int filas = cmd.ExecuteNonQuery();
        //            if (filas > 0)
        //            {
        //                exito = true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("error en el mtdCancelarHorario"+ex.Message);
        //    }
        //    finally
        //    {
        //        con.mtdCerrarConexion();
        //    }
        //    return exito;
        //}

    }
}