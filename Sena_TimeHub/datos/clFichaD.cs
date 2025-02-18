using Newtonsoft.Json;
using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sena_TimeHub.datos
{
    public class clFichaD
    {

        public bool RegistrarFicha(string numeroFicha, DateTime fechaInicio, DateTime fechaFinal,
        string jornada, int idPrograma, int idSede, DataTable aprendices)
        {
            clConexion cone = new clConexion();
            bool validacion = false;
            SqlConnection con = cone.mtdAbrirConexion();

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_GuardarFichaYAprendices", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 📌 Parámetros de la ficha
                    cmd.Parameters.AddWithValue("@numeroFicha", numeroFicha);
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFinal);
                    cmd.Parameters.AddWithValue("@estado", "Activo");  // Ajusta según necesites
                    cmd.Parameters.AddWithValue("@jornada", jornada);
                    cmd.Parameters.AddWithValue("@idPrograma", idPrograma);
                    cmd.Parameters.AddWithValue("@idSede", idSede);

                    // 📌 Convertir DataTable a JSON para enviarlo
                    string jsonAprendices = JsonConvert.SerializeObject(aprendices);
                    cmd.Parameters.AddWithValue("@listaAprendices", jsonAprendices);

                    // 📌 Parámetro de retorno
                    SqlParameter returnParam = new SqlParameter("@ReturnVal", SqlDbType.Int);
                    returnParam.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParam);

                    cmd.ExecuteNonQuery();
                    validacion = true;
                    // 📌 Validar si la ejecución fue exitosa
                    //validacion = (int)returnParam.Value == 1;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
                Console.WriteLine("SQL Error Number: " + ex.Number);
                Console.WriteLine("SQL Error Line: " + ex.LineNumber);
            }
            finally
            {
                cone.mtdCerrarConexion();
            }

            return validacion;
        }

        public List<clProgramaE> ObtenerProgramas()
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            List<clProgramaE> programas = new List<clProgramaE>();

            try
            {

                using (SqlCommand cmd = new SqlCommand("spObtenerProgramas", cone))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clProgramaE programa = new clProgramaE
                            {
                                idPrograma = reader.GetInt32(reader.GetOrdinal("idPrograma")),
                                nombrePrograma = reader.GetString(reader.GetOrdinal("nombrePrograma"))
                            };
                            programas.Add(programa);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("erroro en obtener programas" + e.Message);
            }
            finally
            {
                con.mtdCerrarConexion();

            }

            return programas;
        }

        public List<clSedeE> obtenerSede()
        {
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            List<clSedeE> sedes = new List<clSedeE>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("spObtenerSede", cone))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clSedeE sede = new clSedeE
                            {
                                idSede = reader.GetInt32(reader.GetOrdinal("idSede")),
                                nombreSede = reader.GetString(reader.GetOrdinal("nombreSede"))
                            };
                            sedes.Add(sede);
                        }
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                con.mtdCerrarConexion();
            }
            return sedes;


        }
    }
}
