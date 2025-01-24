using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clRegistrarInstructorD
    {

        public bool mtdRegistroInstructor(clUsuarioE oUsuario, clArea oArea)
        {
            clConexion con = new clConexion();
            SqlConnection conexion = con.mtdAbrirConexion();
            bool exito = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand("spRegistrarInstructor", conexion))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", oUsuario.nombre);
                    cmd.Parameters.AddWithValue("@apellido", oUsuario.apellido);
                    cmd.Parameters.AddWithValue("@tipoDocumento", oUsuario.tipoDocumento);
                    cmd.Parameters.AddWithValue("@documento", oUsuario.documento);
                    cmd.Parameters.AddWithValue("@email", oUsuario.email);


                    cmd.Parameters.AddWithValue("@idRol", oUsuario.idRol);
                    cmd.Parameters.AddWithValue("@idArea", oArea.idArea);
                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0)
                    {
                    exito = true;

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
            return exito;
        }
        public List<clArea> mtdObtenerArea()
        {
            clConexion con = new clConexion();
            SqlConnection con2 = con.mtdAbrirConexion();
            List<clArea> lista = new List<clArea>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("spObtenerArea", con2))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clArea oA = new clArea()
                            {
                                idArea = reader.GetInt32(reader.GetOrdinal("idArea")),
                                nombreArea = reader.GetString(reader.GetOrdinal("nombreArea"))
                            };
                            lista.Add(oA);
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
            return lista;
        }

    }
}