using Sena_TimeHub.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Sena_TimeHub.datos
{
    public class clProgramaD
    {
        public void MtdRegistrarPrograma(clProgramaE objPrograma)
        {
            clConexion objConexion = new clConexion();

            SqlCommand comando = new SqlCommand("sp_RegistroPrograma", objConexion.mtdAbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@programa", objPrograma.nombrePrograma);
            comando.Parameters.AddWithValue("@version", objPrograma.version);
            comando.Parameters.AddWithValue("@codigo", objPrograma.codigo);
            comando.Parameters.AddWithValue("@tipo", objPrograma.tipo);


            comando.ExecuteNonQuery();


            objConexion.mtdCerrarConexion();
        }

    }
}