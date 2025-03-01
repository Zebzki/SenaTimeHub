﻿using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clAprendizD
    {
        public clAprendizE mtdIngresoAprendiz(clAprendizE oData)
        {
            clAprendizE oAprendiz = null;
            clConexion con = new clConexion();
            SqlConnection cone = con.mtdAbrirConexion();
            try
            {
                using (SqlCommand cmd = new SqlCommand("spLoginAprendiz", cone))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = oData.emailAprendiz;
                    cmd.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = oData.contrasenaAprendiz;

                    SqlDataReader reader = cmd.ExecuteReader();
                    
                        if (reader.Read())
                        {
                            oAprendiz = new clAprendizE
                            {
                                idAprendiz = reader.GetInt32(reader.GetOrdinal("idAprendiz")),
                                nombreAprendiz = reader.GetString(reader.GetOrdinal("nombreAprendiz")),
                                apellidoAprendiz = reader.GetString(reader.GetOrdinal("apellidoAprendiz"))
                            };
                        }

                    

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error en mtdIngresoAprendiz{ex.Message}");
            }
            finally
            {
                con.mtdCerrarConexion();
            }
            return oAprendiz;
        }
    }
}