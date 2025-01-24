using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sena_TimeHub.datos
{
    public class clFichaD
    {

        public bool RegistrarFicha(string numeroFicha, DateTime fechaInicio, DateTime fechaFinal, string jornada, int idPrograma, DataTable usuarios)
        {
            clConexion cone = new clConexion();
            bool validacion = false;
            SqlConnection con = cone.mtdAbrirConexion();
            try
            {
               
                    using (SqlCommand cmd = new SqlCommand("spExcelPrueba", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@numeroFicha", numeroFicha);
                        cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);

                        cmd.Parameters.AddWithValue("@fechaFinal", fechaFinal);

                        cmd.Parameters.AddWithValue("@jornada", jornada);
                        cmd.Parameters.AddWithValue("@idPrograma", idPrograma);
                        SqlParameter tvpParam = cmd.Parameters.AddWithValue("@usuarios", usuarios);
                        tvpParam.SqlDbType = SqlDbType.Structured;
                        tvpParam.TypeName = "TVP_Usuarios";
                        int filas = cmd.ExecuteNonQuery();
                        if (filas > 0)
                        {
                            validacion = true;
                        }



                    }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

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
            catch ( Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.mtdCerrarConexion();

            }

            return programas;
        }

    }
}
