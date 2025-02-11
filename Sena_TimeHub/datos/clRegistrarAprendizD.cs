using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Xml.Linq;

namespace Sena_TimeHub.datos
{
    public class clRegistarAprendizD
    {
        private clConexion conexion = new clConexion();

        public bool RegistrarAprendiz(clAprendizE oData, clFichaE oF)
        {
            
            SqlConnection connection = conexion.mtdAbrirConexion();
            SqlCommand command = new SqlCommand("RegistrarAprendizConFicha", connection);
            bool exito = false;
            try
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@nombre", oData.nombreAprendiz);
                command.Parameters.AddWithValue("@apellido", oData.apellidoAprendiz);
                command.Parameters.AddWithValue("@tipoDocumento", oData.tipoDocumentoAprendiz);
                command.Parameters.AddWithValue("@documento", oData.documentoAprendiz);
                command.Parameters.AddWithValue("@email", oData.emailAprendiz);

                command.Parameters.AddWithValue("@idFicha", oF.idFicha);
                command.ExecuteNonQuery();
                exito = true;
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conexion.mtdCerrarConexion();
            }
            
            return exito;

        }



        public List<clFichaE> ObtenerFichas()
        {
            List<clFichaE> listarFichas = new List<clFichaE>();
            SqlConnection connection = conexion.mtdAbrirConexion();

            try
            {
                SqlCommand command = new SqlCommand("ObtenerFichasActivas", connection);
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clFichaE ficha = new clFichaE
                        {
                            idFicha = reader.GetInt32(reader.GetOrdinal("idFicha")),
                            numeroFicha = reader.GetString(reader.GetOrdinal("numeroFicha")),
                            nombrePrograma = reader.GetString(reader.GetOrdinal("nombrePrograma"))
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


