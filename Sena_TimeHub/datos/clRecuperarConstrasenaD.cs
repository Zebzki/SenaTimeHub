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
        public clAprendizE mtdRecuperarContrasenaAp(string correo = null, int idAprendiz = 0, string contrasena = null)
        {
            clAprendizE objAprendiz = new clAprendizE();


            if (correo != null)
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("spRecuperarContrasenaAp", objConexion.mtdAbrirConexion());
                    cmd.Parameters.AddWithValue("@emailAprendiz", correo);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader fila = cmd.ExecuteReader())
                    {
                        if (fila.HasRows)
                        {

                            while (fila.Read())
                            {

                               
                             
                                objAprendiz.idAprendiz = int.Parse(fila["idAprendiz"].ToString());
                                objAprendiz.nombreAprendiz = fila["nombreAprendiz"].ToString();
                                objAprendiz.apellidoAprendiz = fila["apellidoAprendiz"].ToString();
                                objAprendiz.emailAprendiz = fila["emailAprendiz"].ToString();
                                objAprendiz.validarAprendiz = true;

                            }

                        }
                        else
                        {
                            objAprendiz.validarAprendiz = false;
                        }


                        fila.Close();
                        objConexion.mtdCerrarConexion();
                    }


                }
                catch (Exception e)
                {

                    Console.WriteLine($"Error al recuperar datos del aprendiz: {e.Message}");
                }



            }
            else
            {

                if (idAprendiz != 0 && contrasena != null)
                {
                    try
                    {


                        SqlCommand cmd = new SqlCommand("spRecuperarContrasenaAp", objConexion.mtdAbrirConexion());
                        cmd.Parameters.AddWithValue("@idAprendiz", idAprendiz);
                        cmd.Parameters.AddWithValue("@contrasenaAprendiz", contrasena);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        objAprendiz.validarAprendiz = true;

                    }
                    catch (Exception e)
                    {
                        objAprendiz.validarAprendiz = false;
                        Console.WriteLine("error "+e.Message);
                    }
                }
                else
                {

                    objAprendiz.validarAprendiz = false;

                }

            }


            return objAprendiz;

        }

    }

}