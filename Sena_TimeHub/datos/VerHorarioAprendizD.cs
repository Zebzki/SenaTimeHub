using Sena_TimeHub.datos;
using Sena_TimeHub.entidades;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

public class clHorarioAprendiz
{
    public List<clHorario> mtdHorarioAprendiz(int idAprendiz)
    {
        clConexion con = new clConexion();
        SqlConnection cone = con.mtdAbrirConexion();
        List<clHorario> horarios = new List<clHorario>();
        List<DateTime> fechasCanceladas = mtdObtenerFechasCanceladas(idAprendiz);

        try
        {
            using (SqlCommand cmd = new SqlCommand("spObtenerHorario", cone))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idAprendiz", idAprendiz);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       
                        DateTime fechaInicio = reader.IsDBNull(reader.GetOrdinal("fechaInicio")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("fechaInicio"));
                        DateTime fechaFinal = reader.IsDBNull(reader.GetOrdinal("fechaFinal")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("fechaFinal"));

                       
                        TimeSpan horaInicio = reader.IsDBNull(reader.GetOrdinal("horaInicio")) ? TimeSpan.Zero : reader.GetTimeSpan(reader.GetOrdinal("horaInicio"));
                        TimeSpan horaFinal = reader.IsDBNull(reader.GetOrdinal("horaFinal")) ? TimeSpan.Zero : reader.GetTimeSpan(reader.GetOrdinal("horaFinal"));

                        clHorario horario = new clHorario
                        {
                            idHorario = reader.GetInt32(reader.GetOrdinal("idHorario")),
                            fechaInicio = fechaInicio,
                            fechaFinal = fechaFinal,
                            horaInicio = horaInicio,
                            horaFinal = horaFinal,
                           

                            ficha = reader.GetString(reader.GetOrdinal("ficha")),
                            ambiente = reader.GetString(reader.GetOrdinal("ambiente")),
                            instructor = reader.GetString(reader.GetOrdinal("Instructor")),
                            nombreMateria = reader.GetString(reader.GetOrdinal("area")),
                            tipoMateria = reader.GetString(reader.GetOrdinal("tipoArea")),
                            dias = new List<string>()
                        };

                        // Identificar los días de clase
                        if (reader.GetBoolean(reader.GetOrdinal("lunes"))) horario.dias.Add("lunes");
                        if (reader.GetBoolean(reader.GetOrdinal("martes"))) horario.dias.Add("martes");
                        if (reader.GetBoolean(reader.GetOrdinal("miercoles"))) horario.dias.Add("miércoles");
                        if (reader.GetBoolean(reader.GetOrdinal("jueves"))) horario.dias.Add("jueves");
                        if (reader.GetBoolean(reader.GetOrdinal("viernes"))) horario.dias.Add("viernes");
                        if (reader.GetBoolean(reader.GetOrdinal("sabado"))) horario.dias.Add("sábado");

                        // Generar horarios por día en el rango de fechas
                        DateTime currentDate = horario.fechaInicio;
                        while (currentDate <= horario.fechaFinal)
                        {
                            string dayOfWeek = currentDate.ToString("dddd", new System.Globalization.CultureInfo("es-ES")).ToLower();
                            if (horario.dias.Contains(dayOfWeek))
                            {
                                clHorario dayHorario = new clHorario
                                {
                                    idHorario = horario.idHorario,
                                    fechaInicio = currentDate,
                                    fechaFinal = currentDate,
                                    horaInicio = horario.horaInicio,
                                    horaFinal = horario.horaFinal,
                                    ficha = horario.ficha,
                                    ambiente = horario.ambiente,
                                    instructor = horario.instructor,
                                    nombreMateria=horario.nombreMateria,
                                    tipoMateria=horario.tipoMateria,
                                    dias = new List<string> { dayOfWeek },
                                    esCancelada = fechasCanceladas.Contains(currentDate)
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
            Console.WriteLine("Error en mtdHorarioAprendiz: " + ex.Message);
        }
        finally
        {
            con.mtdCerrarConexion();
        }
        return horarios;
    }
    public List<DateTime> mtdObtenerFechasCanceladas(int idAprendiz)
    {
        clConexion con = new clConexion();
        SqlConnection cone = con.mtdAbrirConexion();
        List<DateTime> fechasCanceladas = new List<DateTime>();
        try
        {
            using (SqlCommand cmd = new SqlCommand("sp_ObtenerFechasCanceladasAprendiz", cone))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idAprendiz", idAprendiz);
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
}
