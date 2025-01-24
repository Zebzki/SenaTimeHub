using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clListarAmbienteD
    {

        private clConexion conexion = new clConexion();

        public List<clAmbienteE> MtdListarAmbiente()
        {
            List<clAmbienteE> listarAmbientes = new List<clAmbienteE>();
            SqlConnection connection = conexion.mtdAbrirConexion();

            try
            {
                SqlCommand command = new SqlCommand("spListarAmbienteConSede", connection);
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clAmbienteE ficha = new clAmbienteE
                        {
                            nombreAmbiente = reader["nombreAmbiente"].ToString(),
                            nombreSede = reader["nombreSede"].ToString(), 
                            imagenAmbiente = reader["imagenAmbiente"].ToString(),
                            estado = reader["estado"].ToString(),
                            
                        };
                        listarAmbientes.Add(ficha);
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
            return listarAmbientes;
        }

    }

}
