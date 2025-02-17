using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clObtenerInstructorD
    {
        clConexion conexion = new clConexion();

        public List<clUsuarioE> ObtenerInstructor()
        {
            List<clUsuarioE> listarInstructor = new List<clUsuarioE>();
            SqlConnection connection = conexion.mtdAbrirConexion();

            try
            {
                SqlCommand command = new SqlCommand("spObtenerInstructor", connection);
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clUsuarioE instructor = new clUsuarioE
                        {
                            idUsuario = reader.GetInt32(reader.GetOrdinal("idUsuario")),
                            nombre = reader.GetString(reader.GetOrdinal("nombre")),
                            apellido = reader.GetString(reader.GetOrdinal("apellido"))
                        };
                        listarInstructor.Add(instructor);
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
            return listarInstructor;
        }

    }
}