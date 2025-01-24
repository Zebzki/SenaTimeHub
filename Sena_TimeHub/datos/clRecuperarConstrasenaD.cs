using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clRecuperarConstrasenaD
    {

        clConexion objConexion = new clConexion();


        public clUsuarioE mtdRecuperarContrasena(string correo = null, int idUsuario = 0, string contrasena = null)
        {
            clUsuarioE objUsuarioE = new clUsuarioE();


            if (correo != null)
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("spRecuperarContrasena", objConexion.mtdAbrirConexion());
                    cmd.Parameters.AddWithValue("@email", correo);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader fila = cmd.ExecuteReader())
                    {
                        if (fila.HasRows)
                        {

                            while (fila.Read())
                            {

                                objUsuarioE.idUsuario = int.Parse(fila["idUsuario"].ToString());
                                objUsuarioE.nombre = fila["nombre"].ToString();
                                objUsuarioE.apellido = fila["apellido"].ToString();
                                objUsuarioE.email = fila["email"].ToString();
                                objUsuarioE.validar = true;
                            }

                        }
                        else
                        {
                            objUsuarioE.validar = false;
                        }


                        fila.Close();
                        objConexion.mtdCerrarConexion();
                    }


                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }



            }
            else
            {

                if (idUsuario != 0 && contrasena != null)
                {
                    try
                    {


                        SqlCommand cmd = new SqlCommand("spRecuperarContrasena", objConexion.mtdAbrirConexion());
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmd.Parameters.AddWithValue("@contrasena", contrasena);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        objUsuarioE.validar = true;

                    }
                    catch (Exception e)
                    {
                        objUsuarioE.validar = false;
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {

                    objUsuarioE.validar = false;

                }

            }


            return objUsuarioE;

        }

    }

}