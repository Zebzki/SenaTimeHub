using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clObtenerSedeD
    {
        private clConexion conexion = new clConexion();

        public List<clSedeE> ObtenerSede()
        {
            List<clSedeE> sedes = new List<clSedeE>();

            using (SqlConnection con = conexion.mtdAbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand("spObtenerSede", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clSedeE sede = new clSedeE()
                            {
                                idSede = reader.GetInt32(reader.GetOrdinal("idSede")),
                                nombreSede = reader.GetString(reader.GetOrdinal("nombreSede"))

                            };
                            sedes.Add(sede);
                        }
                    }
                }
            }
            conexion.mtdCerrarConexion();

            return sedes;
        }

        public clSedeE mtdObtenerSede(int id)
        {
            clConexion con = new clConexion();
            SqlConnection conexion = con.mtdAbrirConexion();
            clSedeE oSede = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand("spObtenerSedeConId", conexion))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idSede", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            oSede = new clSedeE()
                            {
                                nombreSede = reader.GetString(reader.GetOrdinal("nombreSede"))

                            };

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
            return oSede;
        }

    }
}