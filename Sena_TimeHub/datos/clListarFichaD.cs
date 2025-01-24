using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clListarFichaD
    {
        private clConexion conexion = new clConexion();

        public List<clFichaE> MtdListarFichas(int idFicha)
        {
            List<clFichaE> listarFichas = new List<clFichaE>();
            SqlConnection connection = conexion.mtdAbrirConexion();

            try
            {
                SqlCommand command = new SqlCommand("spListarFichas", connection);
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clFichaE ficha = new clFichaE
                        {
                            idFicha = Convert.ToInt32(reader["idFicha"]),
                            numeroFicha = reader["numeroFicha"].ToString(),
                            nombrePrograma = reader["nombrePrograma"].ToString(), // Asignación desde clProgramaE
                            fechaInicio = reader["fechaInicio"].ToString(),
                            fechaFinal = reader["fechaFinal"].ToString(),
                            estado = reader["estado"].ToString(),
                            jornada = reader["jornada"].ToString()
                        };
                        listarFichas.Add(ficha);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
            finally
            {
                conexion.mtdCerrarConexion();
            }
            return listarFichas;
        }

    }

}